using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace class_APICSHARP.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Gender { get; set; }
        public string HomePlanet { get; set; }



        public Person(string APIText)
        {
            //inside the contructor parse the apitext in to an object
            JObject personData = JObject.Parse(APIText);

            Name = personData["name"].ToString();
            Species = personData["species"][0].ToString();
            Gender = personData["gender"].ToString();
            HomePlanet = personData["homeworld"].ToString();
        }
    }
}