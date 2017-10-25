namespace XmlFeeder.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using XmlFeeder.Models;

    public interface IXmlFeederContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<Bet> Bets { get; set; }

        IDbSet<Event> Events { get; set; }

        IDbSet<Match> Matches { get; set; }

        IDbSet<Odd> Odds { get; set; }

        IDbSet<Sport> Sports { get; set; }
    }
}
