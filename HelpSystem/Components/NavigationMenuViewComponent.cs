using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HelpSystem.Models;
using HelpSystem.Infrastructure.Services;
using HelpSystem.Infrastructure.Services.CategoryServices.Requests;

using HelpSystem.Infrastructure;

namespace HelpSystem.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        IRequestSender _sender;

        public NavigationMenuViewComponent(IRequestSender sender) => _sender = sender;

        public IViewComponentResult Invoke()
        {
            var result = _sender.Send<GetMainCategoriesQuery, IEnumerable<Category>>(new GetMainCategoriesQuery());

            return View(result);
            //return View(new List<String>() { "C#", "EF Core", "ASP.NET", "WPF" });
        }
    }
}
