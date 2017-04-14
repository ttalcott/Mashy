using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;

namespace Mashy.Controllers
{
    public class YelpSearchController 
    {
        [HttpGet]
        public List<Models.SearchDTO> Get()
        {
            var model = new List<Models.YelpSearch>();

            String request = YelpAPI.PerformRequest();


            //Convert Response to model
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Models.YelpSearch));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(request)))
            {
                var searchResults = (Models.YelpSearch)serializer.ReadObject(ms);

                model.Add(searchResults);
            }

            var search = from s in model
                         from b in s.businesses
                         select new Models.SearchDTO()
                         {
                             id = b.id,
                             name = b.name,
                             display_phone = b.display_phone,
                             image_url = b.image_url,
                             rating = b.rating,
                             url = b.url,
                             address = b.location.address,
                             city = b.location.city,
                             postal_code = b.location.postal_code,
                             state_code = b.location.state_code
                         };

            return search.ToList();
        }

        public List<Models.YelpSearch.Business> Get(string id)
        {
            var model = new List<Models.YelpSearch.Business>();

            String request = YelpAPI.BusinessRequest(id);


            //Convert Response to model
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Models.YelpSearch.Business));
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(request)))
            {
                var searchResults = (Models.YelpSearch.Business)serializer.ReadObject(ms);

                model.Add(searchResults);
            }

            return model;
        }


        //[HttpGet]
        //public String GetString()
        //{
        //    var model = new List<Models.Search>();

        //    String request = YelpAPI.PerformRequest();

        //    return request;
        //}

    }
}
