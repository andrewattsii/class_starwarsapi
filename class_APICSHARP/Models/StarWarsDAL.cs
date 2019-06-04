using System;
using System.Collections.Generic;
using System.IO;

using System.Linq;
using System.Net;
using System.Web;

namespace class_APICSHARP.Models
{
    public class StarWarsDAL
    {
        public static string GetData(String url)
        {
            //1
            HttpWebRequest request = WebRequest.CreateHttp(url);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                return data.ReadToEnd();
            }
            return "";
            //1
        }
        public static Person GetPerson(int i)
        {
            string data = GetData($"https://swapi.co/api/people/{i}/");
            return new Person(data);
        }
        public static Planet GetPlanet(int i)
        {
            string planetData = GetData($"https://swapi.co/api/planets/{i}/");
            return new Planet(planetData);
        }
    }
}