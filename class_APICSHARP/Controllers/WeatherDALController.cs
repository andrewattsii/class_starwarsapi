using class_APICSHARP.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace class_APICSHARP.Controllers
{
    public class WeatherDALController : Controller
    {
        // GET: WeatherDAL
        //this controller is wherer we are using thr DAL to talk to our api

            //this actionreault wil l access teh dal and create an object of the api
        public ActionResult GetWeather(int index)
        {
            WeatherDAL weatherData = new WeatherDAL();
            JObject weather = weatherData.GetWeatherAPI("38.4247341", "-86.9624086");
            weatherData.StartPeriodName = (string)weather["time"]["startPeriodName"][index];
            return View();
        }
    }
}