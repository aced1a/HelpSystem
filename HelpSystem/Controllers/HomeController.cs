using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HelpSystem.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View(new List<String>() { "Hello", "World" });
        }

        public IActionResult List()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
