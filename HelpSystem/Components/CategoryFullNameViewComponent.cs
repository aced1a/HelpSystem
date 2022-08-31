using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HelpSystem.Models;
using HelpSystem.Infrastructure.Services;
using HelpSystem.Infrastructure.Services.CategoryServices.Requests;

namespace HelpSystem.Components
{
    public class CategoryFullNameViewComponent : ViewComponent
    {
        IRequestSender _sender;

        public CategoryFullNameViewComponent(IRequestSender sender)
        {
            _sender = sender;
        }

        public IViewComponentResult Invoke(int id)
        {

            var categories = _sender.Send<GetCategoryFullNameQuery, IEnumerable<Category>>
                (new GetCategoryFullNameQuery() { Id = id });

            return View(categories);
        }
    }
}
