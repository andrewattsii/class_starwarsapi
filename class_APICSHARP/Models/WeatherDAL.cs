using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace class_APICSHARP.Models
{
    public class WeatherDAL
    {
        //properties for our api end pints
        public string StartPeriodName { get; set; }
        public string StartPeriodTime { get; set; }
        public string  Temp { get; set; }
        public string Pop { get; set; }


        //methods for calling our api's 
        public  JObject GetWeatherAPI(string latitude, string longitude)
        {
            HttpWebRequest request = WebRequest.CreateHttp($"https://forecast.weather.gov/MapClick.php?lat="+latitude+"lon="+longitude+"&FcstType=xml");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if(response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                JObject weatherData = new JObject(data.ReadToEnd());
                return weatherData;
            }
            return null;
        }
        
    }
}