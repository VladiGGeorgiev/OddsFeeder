using System.Collections.Generic;

namespace XmlFeeder.Web.ViewModels
{
    public class BetViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public IEnumerable<OddViewModel> Odds { get; set; }
    }
}