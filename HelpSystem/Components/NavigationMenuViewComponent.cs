using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HelpSystem.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public NavigationMenuViewComponent() { }

        public IViewComponentResult Invoke()
        {
            return View(new List<String>() { "C#", "EF Core", "ASP.NET" });
        }
    }
}
