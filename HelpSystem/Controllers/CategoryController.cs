using Microsoft.AspNetCore.Mvc;
using HelpSystem.Infrastructure.Services;

namespace HelpSystem.Controllers
{
    public class CategoryController : Controller
    {
        IRequestSender _sender;

        public CategoryController(IRequestSender sender) => _sender = sender;

        public IActionResult Index()
        {
            return View();
        }
    }
}
