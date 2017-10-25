namespace XmlFeeder.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class XmlSports
    {
        public DateTime CreateDate { get; set; }
        
        public List<Sport> Sports { get; set; }
    }

    public class XmlSportsWrapper
    {
        public XmlSports XmlSports { get; set; }
    }
}
