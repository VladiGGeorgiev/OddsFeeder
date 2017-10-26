namespace XmlFeeder.Services
{
    using XmlFeeder.Services.Models;

    public interface ISportsDataPopulationService
    {
        void PupulateData(DataModel data);
    }
}