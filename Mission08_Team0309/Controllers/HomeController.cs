using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Tasks()
        {
            
            ViewBag.Category = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View("Tasks");
        }

        [HttpPost]
        public IActionResult Tasks(Item response)
        {
            if (ModelState.IsValid)
            {
                _context.Items.Add(response);
                _context.SaveChanges();

                return View(response);
            }

            else
            {
                ViewBag.Category = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
                return View(response);
            }
            
            
        }

        public IActionResult Quadrant()
        {
            var quadrant = _context.Items
                .OrderBy(x => x.Id).ToList();

            return View(quadrant);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Items.FirstOrDefault(x => x.Id == id);

            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

            return View("Tasks", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Item updatedInfo) 
        { 
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var recordToDelete = _context.Items.FirstOrDefault(x => x.Id == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Item items)
        {
            _context.Items.Remove(items);
            _context.SaveChanges();

            return RedirectToAction("Quadrant");
        }


    }
}