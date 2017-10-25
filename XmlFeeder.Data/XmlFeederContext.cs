namespace XmlFeeder.Data
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using XmlFeeder.Models;

    public class XmlFeederContext : DbContext, IXmlFeederContext
    {
        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Odd> Odds { get; set; }

        public IDbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Event>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Match>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Odd>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Sport>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            base.OnModelCreating(modelBuilder);
        }
    }
}
