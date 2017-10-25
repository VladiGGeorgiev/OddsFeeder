namespace XmlFeeder.Web.Controllers
{
    using System.Web.Mvc;
    using XmlFeeder.Services;

    public class HomeController : Controller
    {
        public HomeController(IXmlFeederRequester requester)
        {
        }

        public ActionResult Index()
        {
            return View();
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