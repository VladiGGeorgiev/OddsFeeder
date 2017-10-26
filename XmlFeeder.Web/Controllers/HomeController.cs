namespace XmlFeeder.Web.Controllers
{
    using System.Web.Mvc;
    using XmlFeeder.Services;
    using XmlFeeder.Services.Models;

    public class HomeController : Controller
    {
        private readonly ISportsService sportsService;

        public HomeController(ISportsService sportsService)
        {
            this.sportsService = sportsService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSports()
        {
            var sportsVM = new SportsModel { Sports = this.sportsService.GetAllSports() };
            JsonResult json = Json(sportsVM, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}