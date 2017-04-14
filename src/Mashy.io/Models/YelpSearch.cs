using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mashy.Models
{
    public class YelpSearch
    {
        public class Coordinate
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
        }

        public class Location
        {
            public List<string> address { get; set; }
            public string city { get; set; }
            public Coordinate coordinate { get; set; }
            public string country_code { get; set; }
            public string cross_streets { get; set; }
            public List<string> display_address { get; set; }
            public double geo_accuracy { get; set; }
            public List<string> neighborhoods { get; set; }
            public string postal_code { get; set; }
            public string state_code { get; set; }
        }

        public class Business
        {
            public List<List<string>> categories { get; set; }
            public string display_phone { get; set; }
            public string id { get; set; }
            public string image_url { get; set; }
            public bool is_claimed { get; set; }
            public bool is_closed { get; set; }
            public Location location { get; set; }
            public string mobile_url { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public double rating { get; set; }
            public string rating_img_url { get; set; }
            public string rating_img_url_large { get; set; }
            public string rating_img_url_small { get; set; }
            public int review_count { get; set; }
            public string snippet_image_url { get; set; }
            public string snippet_text { get; set; }
            public string url { get; set; }
        }
        [DataMember]
        public List<Business> businesses { get; set; }
        [DataMember]
        public int total { get; set; }

    }
}
