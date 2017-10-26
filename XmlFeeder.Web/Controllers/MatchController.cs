namespace XmlFeeder.Web.Controllers
{
    using System.Web.Mvc;
    using XmlFeeder.Services;

    public class MatchController : Controller
    {
        private readonly IMatchesService matchesService;

        public MatchController(IMatchesService matchesService)
        {
            this.matchesService = matchesService;
        }

        public ActionResult Index(int id)
        {
            var match = this.matchesService.GetMatch(id);
            if (match == null)
            {
                this.RedirectToAction("Index", "Home");
            }

            return this.View(match);
        }
    }
}