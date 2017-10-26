namespace XmlFeeder.Services
{
    using System.IO;
    using XmlFeeder.Services.Models;

    public class XmlFeederSerializer : IXmlFeederSerializer
    {
        public XmlSports Deserialize(string xmlFeed)
        {
            XmlSports sports = null;
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(XmlSports));
            StringReader reader = new StringReader(xmlFeed);
            using (reader)
            {
                sports = (XmlSports)serializer.Deserialize(reader);
                reader.Close();
            }

            return sports;
        }
    }
}
