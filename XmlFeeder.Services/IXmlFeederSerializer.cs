namespace XmlFeeder.Services
{
    using XmlFeeder.Services.Models;

    public interface IXmlFeederSerializer
    {
        XmlSports Deserialize(string xmlFeed);
    }
}
