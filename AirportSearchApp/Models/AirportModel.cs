using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportSearchApp.Models
{
    public class AirportModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public Location location { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string timezone { get; set; }
        public Terminal[] terminals { get; set; }
        public string[] airlines { get; set; }
        public string[] services { get; set; }
        public Contact_Info contact_info { get; set; }

        public class Location
        {
            public float latitude { get; set; }
            public float longitude { get; set; }
        }

        public class Contact_Info
        {
            public string phone { get; set; }
            public string email { get; set; }
            public string website { get; set; }
        }

        public class Terminal
        {
            public string name { get; set; }
            public Gate[] gates { get; set; }
        }

        public class Gate
        {
            public string gate_number { get; set; }
            public string[] airlines { get; set; }
        }
        public string personName => "Josue Valencia";
    }
}
