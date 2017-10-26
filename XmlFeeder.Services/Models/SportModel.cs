namespace XmlFeeder.Services.Models
{
    using System.Collections.Generic;

    public class SportModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<EventModel> Events { get; set; }
    }
}