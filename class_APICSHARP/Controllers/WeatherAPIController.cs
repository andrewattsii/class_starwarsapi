using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace class_APICSHARP.Controllers
{
    public class WeatherAPIController : Controller
    {
        // GET: WeatherAPI
        public ActionResult Index()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=38.4247341&lon=-86.9624086&FcstType=json");

            request.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if(response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                ViewBag.RawData = reader.ReadToEnd();
            }
            return View();
        }
        public ActionResult GetTodaysWeather()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=38.4247341&lon=-86.9624086&FcstType=json");

            request.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                JObject weatherData = JObject.Parse(data.ReadToEnd());
                ViewBag.Today = weatherData["time"]["startPeriodName"];
            }
            return View();
        }
        public ActionResult GetXMLData()
        {
            //add system .net in using                                                                                    json to xml below at end
            HttpWebRequest request = WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=38.4247341&lon=-86.9624086&FcstType=xml");
            //this is the user agent that tells the program what browesers are supposrted, some servers wont work without the user agent selected
            //also tells the server that this is a legitimate request
            request.UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";
            //after the response had been crated get our  reponse from the api
            //***request made get that data
            //we will have to cast the webresponse to a http web response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //create a if statememnt to validate that the api request was succussful 
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //prasr the response data via StreamReader and add system.io to the using systems 
                //streamreader readsa the info from the file 
                StreamReader data = new StreamReader(response.GetResponseStream());
                //creating a empty xml document instead of jobject add system.xml to namespace
                XmlDocument xmlData = new XmlDocument();
                //after empty xmldocument we load our xml data with information from our streamreader
                xmlData.LoadXml(data.ReadToEnd());
                //CreateActionInvoker viewbag
                //and navigate throught he trees for xml the same way we navigate through json with using jsonview.stack.hu
                ViewBag.XmlData = xmlData["data"]["temperature"];
            }
            return View();
        }
    }
    
    
}