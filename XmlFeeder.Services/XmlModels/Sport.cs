namespace XmlFeeder.Services
{
    using System.Collections.Generic;

    public class Sport
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Event> Events { get; set; }
    }
}
