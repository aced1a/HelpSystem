using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HelpSystem.Components
{
    public class NavigationBarViewComponent : ViewComponent
    {
        public NavigationBarViewComponent() { }

        public IViewComponentResult Invoke()
        {
            //get current user and move it in view
            return View();
        }
    }
}
