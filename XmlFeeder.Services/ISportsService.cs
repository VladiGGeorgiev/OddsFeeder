namespace XmlFeeder.Services
{
    using System.Collections.Generic;
    using XmlFeeder.Services.Models;

    public interface ISportsService
    {
        IEnumerable<SportModel> GetAllSports();
    }
}
