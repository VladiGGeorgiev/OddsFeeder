namespace XmlFeeder.Services
{
    using XmlFeeder.Services.Models;

    public interface IXmlFeederRequester
    {
        /// <summary>
        ///     Get sports feed from the VitalBet
        /// </summary>
        /// <returns>Xml sports feed from VitalBet</returns>
        XmlSports GetFeed();
    }
}