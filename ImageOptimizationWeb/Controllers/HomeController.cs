using System.Web.Mvc;

namespace ImageOptimizationWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.PageTitle = "Home";

            ViewBag.Description =
                "Image Optimization - This site contains a collection of best practices for image optimization techniques.";

            return View();
        }

        public ActionResult Compressive()
        {
            ViewBag.PageTitle = "Compressive";

            ViewBag.Description =
                "Compressive Images - This site contains a collection of best practices for image optimization techniques.";

            return View();
        }
        
        public ActionResult DataUri()
        {
            ViewBag.PageTitle = "Data Uris";

            ViewBag.Description =
                "Image Optimization - This site contains a collection of best practices for image optimization techniques.";

            return View();
        }

        public ActionResult WebP()
        {
            ViewBag.PageTitle = "WebP";

            ViewBag.Description =
                "WebP images - This site contains a collection of best practices for image optimization techniques.";

            return View();
        }

        public ActionResult LazyLoad()
        {
            ViewBag.PageTitle = "Lazy Loading Images";

            ViewBag.Description =
                "Lazy Loading Images - This site contains a collection of best practices for image optimization techniques.";

            return View();
        }

        public ActionResult Sprites()
        {
            ViewBag.PageTitle = "CSS Sprites";

            ViewBag.Description =
                "Css Sprites - This site contains a collection of best practices for image optimization techniques.";

            return View();
        }

        public ActionResult Tools()
        {
            ViewBag.PageTitle = "Image Optimization Tools";

            ViewBag.Description =
                "Image Optimization Tools - This site contains a collection of best practices for image optimization techniques.";

            return View();
        }

        public ActionResult PictureElement()
        {
            ViewBag.PageTitle = "Picture Element HTML5";

            ViewBag.Description =
                "Picture Element HTML5 - This site contains a collection of best practices for image optimization techniques.";

            return View();
        }
    }
}
