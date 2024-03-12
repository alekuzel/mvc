using Microsoft.AspNetCore.Mvc;

namespace MvcLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

      

        public IActionResult About()
        {
            return View();
        }
         [Route("/omoss")]

        public IActionResult Cats()
        {
            return View();
        }
          [Route("/katter")]


    }
}