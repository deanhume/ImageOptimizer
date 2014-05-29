using System.Web.Mvc;

namespace ImageOptimizationWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.PageTitle = "Home";

            return View();
        }

        public ActionResult Compressive()
        {
            ViewBag.PageTitle = "Compressive";

            return View();
        }
        
        public ActionResult DataUri()
        {
            ViewBag.PageTitle = "Data Uris";

            return View();
        }

        public ActionResult WebP()
        {
            ViewBag.PageTitle = "WebP";

            return View();
        }

        public ActionResult LazyLoad()
        {
            ViewBag.PageTitle = "LazyLoad";

            return View();
        }

        public ActionResult Sprites()
        {
            ViewBag.PageTitle = "Sprites";

            return View();
        }

        public ActionResult Tools()
        {
            ViewBag.PageTitle = "Optimisation Tools";

            return View();
        }
    }
}
