using Microsoft.AspNetCore.Mvc;
using Mission08_Team0309.Models;
using System.Diagnostics;

namespace Mission08_Team0309.Controllers
{
    public class HomeController : Controller
    {    
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Task()
        {
            return View();
        }

    }
}
