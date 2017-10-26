namespace XmlFeeder.Services
{
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Deserializers;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    using XmlFeeder.Services.Models;

    public class XmlFeederRequester : IXmlFeederRequester
    {
        public string GetFeed()
        {
            // int? days, string date, int? sportID, string lang, bool? isLive
            var client = new RestClient("https://vitalbet.net/sportxml/index");

            var request = new RestRequest(Method.GET);
            //request.AddParameter("isLive", "true");
            request.RequestFormat = DataFormat.Xml;
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/xml"; };

            IRestResponse response = client.Execute(request);
            
            return response.Content;
        }
    }
}
