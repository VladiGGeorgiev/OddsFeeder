namespace XmlFeeder.Models
{
    using System.Collections.Generic;

    public class Sport
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public virtual List<Event> Events { get; set; }
    }
}
