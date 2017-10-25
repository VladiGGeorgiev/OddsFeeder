namespace XmlFeeder.Data.Repositories
{
    using XmlFeeder.Models;

    public class SportsRepository : GenericRepository<Sport>, ISportsRepository
    {
        public SportsRepository(IXmlFeederContext context) : base(context)
        {
        }
    }
}
