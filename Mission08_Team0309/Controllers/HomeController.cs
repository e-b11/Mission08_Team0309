using Microsoft.AspNetCore.Mvc;
using Mission08_Team0309.Models;
using System.Diagnostics;

namespace Mission08_Team0309.Controllers
{
    public class HomeController : Controller
    {
        private IToDoListRepository repo;

        public HomeController(IToDoListRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Task()
        {   
            ViewBag.Category = repo.Category
                .OrderBy(x => x.CategoryName)
                .ToList();
            return base.View("Task", new Item();
        }

        [HttpPost]
        public IActionResult Task(Item i)
        {   
            if (ModelState.IsValid) 
            {
                repo.AddItem(i);
            }
            return View(i);
        }

        public IActionResult Quadrant()
        {
            var items = repo.Items.ToList();

            return View(items);
        }
    }
}
