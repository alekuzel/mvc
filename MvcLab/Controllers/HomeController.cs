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

        public IActionResult Cats()
        {
            return View();
        }


    }
}