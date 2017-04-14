using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using System.Device;
using System.Device.Location;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Mashy.Controllers
{
    internal class YelpAPI
    {
        private static string YelpKey = Microsoft.IdentityModel.Protocols.ConfigurationManager.AppSettings["YelpKey"];
        private static string YelpSecret = ConfigurationManager.AppSettings["YelpSecret"];
        private static string BaseURL = ConfigurationManager.AppSettings["BaseURL"];

        internal static string PerformRequest()
        {
            double latitude = 0;
            double longitude = 0;
            string latLong = string.Empty;
            int counter = 0;



            //create the default query
            var queryString = System.Web.HttpUtility.ParseQueryString(String.Empty);
            if (latitude.ToString() == "NaN")
            {
                queryString["location"] = "87109";
            }
            else
            {
                queryString["ll"] = latLong;
            }
            queryString["term"] = "brewery";
            queryString["limit"] = "10";

            //create the REST web request
            var uri = new UriBuilder(BaseURL + "/search");
            uri.Query = queryString.ToString();
            StreamReader stream = callApi(uri);

            return stream.ReadToEnd();
        }

        private static StreamReader callApi(UriBuilder uri)
        {
            var request = WebRequest.Create(uri.ToString());
            request.Method = "GET";


            //sign the request Yelps Authentication OAuth tokens
            request.SignRequest(
                new Tokens
                {
                    ConsumerKey = ConsumerKey,
                    ConsumerSecret = ConsumerSecret,
                    AccessToken = Token,
                    AccessTokenSecret = TokenSecret
                }).WithEncryption(EncryptionMethod.HMACSHA1).InHeader();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //convert to string an return to controller
            var stream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            return stream;
        }

        internal static string BusinessRequest(string id)
        {
            var uri = new UriBuilder(BaseURL + "/business/" + id);

            StreamReader stream = callApi(uri);
            return stream.ReadToEnd();
        }
    }
}
