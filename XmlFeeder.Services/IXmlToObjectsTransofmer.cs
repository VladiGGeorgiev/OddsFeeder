namespace XmlFeeder.Services
{
    using XmlFeeder.Services.Models;

    public interface IXmlToObjectsTransofmer
    {
        XmlSports Transform(string xmlFeed);
    }
}
