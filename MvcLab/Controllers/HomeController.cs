using Microsoft.AspNetCore.Mvc;

namespace MvcLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [Route("/omoss")] // Route for the About action method
        [Route("/about")] // Alternate route for the About action method
        public IActionResult About()
        {
            return View();
        }

        [Route("/katter")] // Route for the Cats action method
        public IActionResult Cats()
        {
            return View();
        }

        
    }
}
