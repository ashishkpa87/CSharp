using System;
using System.Net;
using static System.Console;
using Newtonsoft.Json;

namespace GeoLocationUsingCSharp
{

    public class IPData
    {
        public string status { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timeZone { get; set; }
        public string isp { get; set; }
        public string org { get; set; }
        public string @as { get; set; }
        public string query { get; set; }
    }
    class GetGeoLoc
    {
        static void Main(string[] args)
        {
            WriteLine("In to Main()");
            IPData ipdata = new GetGeoLoc().GetIPGeoLocation("60.243.252.141");
            WriteLine();
            WriteLine("status - "+ipdata.status);
            WriteLine("country - " + ipdata.country);
            WriteLine("country code- " + ipdata.countryCode);
            WriteLine("region- "+ipdata.region);
            WriteLine("regionName- " + ipdata.regionName);
            WriteLine("city- " + ipdata.city);
            WriteLine("zip- " + ipdata.zip);
            WriteLine("lat- " + ipdata.lat);
            WriteLine("lon- " + ipdata.lon);
            WriteLine("timeZone- " + ipdata.timeZone);
            WriteLine("isp- " + ipdata.isp);
            WriteLine("org- " + ipdata.org);
            WriteLine("@as- " + ipdata.@as);
            WriteLine("query- " + ipdata.query);
            ReadKey();
        }

        public IPData GetIPGeoLocation(string IP)
        {
            WebClient client = new WebClient();
            //make an api call to get the rsponse
            try
            {
                ///Using DownloadString(String) version
                //string response = client.DownloadString("http://ip-api.com/json/" + IP);      
                //OR        ///Using DownloadString(URI) version
                string response = client.DownloadString(new Uri("http://ip-api.com/json/" + IP));
                WriteLine("In GetIPGeoLocation - "+response);
                //Deserialize the response JSON
                IPData ipdata = JsonConvert.DeserializeObject<IPData>(response);
                if (ipdata.status == "fail")
                {
                    throw new Exception("Invalid IP");
                }
                return ipdata;
            }
            catch (Exception E)
            {
                throw;
                //return null;
            }
            
        }
    }
}
