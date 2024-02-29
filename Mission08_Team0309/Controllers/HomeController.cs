using Microsoft.AspNetCore.Mvc;
using Mission08_Team0309.Models;
using System.Diagnostics;

namespace Mission08_Team0309.Controllers
{
    public class HomeController : Controller
    {
        private ToDoListContext _context;

        public HomeController(ToDoListContext temp)
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Task()
        {
            ViewBag.Category = _context.Category
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Task");
        }

        [HttpPost]
        public IActionResult Task(Item response)
        {
            _context.Item.Add(response);
            _context.SaveChanges();

            return View( response);
        }

        public IActionResult Quadrant()
        {
            var item = _context.Item
                .OrderBy(x => x.DueDate).ToList();

            return View(item);
        }
    }
}
