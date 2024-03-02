using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Mission08_Team0309.Models;
using System.Diagnostics;

namespace Mission08_Team0309.Controllers
{
    public class HomeController : Controller
    {
        private IToDoListRepository _itemRepository;

        public HomeController(IToDoListRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Tasks()
        {
            ViewBag.Categories = _itemRepository.Categories.ToList();
            
            return View();
        }

        [HttpPost]
        public IActionResult Tasks(Item response)
        {
            if (ModelState.IsValid)
            {
                _itemRepository.AddItem(response);

                return View(response);
            }

            else
            {
                ViewBag.Category = _itemRepository.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
                return View(response);
            }
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            var submittedTasks = _itemRepository;

            return View(submittedTasks);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var recordToEdit = _itemRepository.Items
                .Single(x => x.Id == id);

            ViewBag.Categories = _itemRepository.Categories.ToList()
                .OrderBy(x => x.CategoryName).ToList();

            return View("Tasks", recordToEdit);
        }

        [HttpPost]
        public IActionResult Update(Item updatedInfo)
        {
            _itemRepository.UpdateItem(updatedInfo);

            return RedirectToAction("Quadrant");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _itemRepository.Items
                .Single(x => x.Id == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Item items)
        {
            _itemRepository.DeleteItem(items);

            return RedirectToAction("Quadrant");
        }
    }
}