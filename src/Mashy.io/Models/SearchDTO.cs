using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mashy.Models
{
    public class SearchDTO
    {
        public string id { get; set; }
        public string name { get; set; }
        public string display_phone { get; set; }
        public string image_url { get; set; }
        public double rating { get; set; }
        public string url { get; set; }
        public List<string> address { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string state_code { get; set; }
    }
}
