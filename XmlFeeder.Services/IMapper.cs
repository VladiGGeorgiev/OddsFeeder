namespace XmlFeeder.Services
{
    using System.Collections.Generic;
    using XmlFeeder.Services.Models;

    public interface IMapper
    {
        DataModel MapXmlSportsToDataModels(List<Sport> sports);
    }
}
