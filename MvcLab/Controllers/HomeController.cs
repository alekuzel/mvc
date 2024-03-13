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

        [HttpGet]
    public IActionResult EditCat(int id)
    {
        // Load the cat from your data source using the id
        var cat = new CatsModel(); // Replace this with your actual code

        // Return a view with a form to edit the cat
        return View(cat);
    }

    [HttpPost]
    public IActionResult EditCat(int id, CatsModel model)
    {
        if (ModelState.IsValid)
        {
            // Save the updated cat to your data source
            // Replace this with your actual code

            // Redirect to the cats list
            return RedirectToAction("Index");
        }

        // If the model is not valid, return the form view with the current model to display validation errors
        return View(model);
    }

     public IActionResult DeleteCat(int id)
    {
        // Load the cats from your data source
        var cats = new List<CatsModel>(); // Replace this with your actual code

        // Find the cat with the given id and remove it
        var cat = cats.FirstOrDefault(c => c.Id == id);
        if (cat != null)
        {
            cats.Remove(cat);

            // Save the updated list of cats to your data source
            // Replace this with your actual code
        }

        // Redirect to the cats list
        return RedirectToAction("Index");
    }

        public IActionResult Index()
        {

            string jsonStr = System.IO.File.ReadAllText("cats.json");
               
             var cats = JsonSerializer.Deserialize<List<CatsModel>>(jsonStr);
            return View(cats);
        }

        [Route("/omoss")]
        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("/katter")]
        [Route("/cats")]
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
                ModelState.Clear();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Handle validation error
                return View("Error");
            }

            
        }
    }
}