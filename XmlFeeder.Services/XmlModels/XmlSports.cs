namespace XmlFeeder.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    public class XmlSports
    {
        [XmlAttribute]
        public DateTime CreateDate { get; set; }
        
        [XmlElement("Sport")]
        public List<Sport> Sports { get; set; }
    }
}
