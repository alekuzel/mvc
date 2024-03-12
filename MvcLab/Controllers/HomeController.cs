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
        [Route("/about")] // same routes name in english. both will lead to the same destination
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
