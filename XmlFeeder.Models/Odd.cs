namespace XmlFeeder.Models
{
    public class Odd
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Value { get; set; }

        public string SpecialBetValue { get; set; }

        public int BetId { get; set; }

        public Bet Bet { get; set; }
    }
}
