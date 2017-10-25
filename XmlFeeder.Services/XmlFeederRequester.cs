namespace XmlFeeder.Services
{
    using Newtonsoft.Json;
    using RestSharp;
    using RestSharp.Deserializers;
    using System.IO;
    using System.Xml.Serialization;
    using XmlFeeder.Services.Models;

    public class XmlFeederRequester : IXmlFeederRequester
    {
        public XmlSports GetFeed()
        {
            // int? days, string date, int? sportID, string lang, bool? isLive
            var client = new RestClient("https://vitalbet.net/sportxml/index");

            var request = new RestRequest(Method.GET);
            //request.AddParameter("isLive", "true");
            request.RequestFormat = DataFormat.Xml;
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/xml"; };

            IRestResponse<XmlSports> response = client.Execute<XmlSports>(request);
            
            //XmlSerializer serializer = new XmlSerializer(typeof(XmlSports));
            //StringReader stringReader = new StringReader(response.Content);
            //var result = (XmlSports)serializer.Deserialize(stringReader);

            return response.Data;
        }
    }
}
