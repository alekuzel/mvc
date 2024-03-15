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
        // Retrieves a cat by ID for editing
        [HttpGet]
        public IActionResult EditCat(int id)
        {
            var cats = GetCatsFromJsonFile();
            var cat = cats.FirstOrDefault(c => c.Id == id);
            if (cat == null)
            {
                return View("Error");
            }
            return View(cat);
        }

        // Updates cat information
        [HttpPost]
        public IActionResult EditCat(CatsModel model)
        {
            var cats = GetCatsFromJsonFile();
            var cat = cats.FirstOrDefault(c => c.Id == model.Id);
            if (cat == null)
            {
                return View("Error");
            }

            cat.Name = model.Name;
            cat.Breed = model.Breed;
            cat.Color = model.Color;
            cat.Age = model.Age;

            SaveCatsToJsonFile(cats);

            return RedirectToAction("Index");
        }

        // Retrieves cats data from JSON file
        private List<CatsModel> GetCatsFromJsonFile()
        {
            string jsonStr = System.IO.File.ReadAllText("cats.json");
            return JsonSerializer.Deserialize<List<CatsModel>>(jsonStr);
        }

        // Saves cats data to JSON file
        private void SaveCatsToJsonFile(List<CatsModel> cats)
        {
            string jsonStr = JsonSerializer.Serialize(cats);
            System.IO.File.WriteAllText("cats.json", jsonStr);
        }

        // Deletes a cat by ID
        public IActionResult DeleteCat(int id)
        {
            var cats = GetCatsFromJsonFile();
            var cat = cats.FirstOrDefault(c => c.Id == id);
            if (cat != null)
            {
                cats.Remove(cat);
                SaveCatsToJsonFile(cats);
            }
            else
            {
                // If the cat was not found, return an error view
                return View("Error");
            }

            return RedirectToAction("Index");
        }

        // Displays the list of cats
        public IActionResult Index()
        {
            string jsonStr = System.IO.File.ReadAllText("cats.json");
            var cats = JsonSerializer.Deserialize<List<CatsModel>>(jsonStr);
            return View(cats);
        }

        // Displays information about the application
        [Route("/omoss")]
        [Route("/about")]
        public IActionResult About()
        {
            string jsonStr = System.IO.File.ReadAllText("cats.json");
            var cats = JsonSerializer.Deserialize<List<CatsModel>>(jsonStr);
            ViewBag.TotalCats = cats.Count;
            return View();
        }

        // Displays the cats view
        [Route("/katter")]
        [Route("/cats")]
        public IActionResult Cats()
        {
            return View();
        }

        // Adds a new cat
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
