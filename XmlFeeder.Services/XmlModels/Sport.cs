namespace XmlFeeder.Services
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    public class Sport
    {
        [XmlAttribute]
        public int ID { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement("Event")]
        public List<Event> Events { get; set; }
    }
}
