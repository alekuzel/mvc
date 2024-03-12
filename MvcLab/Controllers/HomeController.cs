using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MvcLab.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace MvcLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/omoss")]
        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("/katter")]
        public IActionResult Cats()
        {
            return View();
        }

        [Route("/katter/add")]
        [HttpPost]
        public async Task<IActionResult> AddCat(CatsModel model)
        {
            if (ModelState.IsValid)
            {
                string jsonStr;
                try
                {
                    jsonStr = await System.IO.File.ReadAllTextAsync("cats.json");
                }
                catch (IOException)
                {
                    // Handle error
                    return View("Error");
                }

                var cats = JsonSerializer.Deserialize<List<CatsModel>>(jsonStr);

                if (cats != null)
                {
                    cats.Add(model);
                    jsonStr = JsonSerializer.Serialize(cats);
                    try
                    {
                        await System.IO.File.WriteAllTextAsync("cats.json", jsonStr);
                    }
                    catch (IOException)
                    {
                        // Handle error
                        return View("Error");
                    }
                }
            }
            else
            {
                // Handle validation error
                return View("Error");
            }

            return View("Cats");
        }
    }
}