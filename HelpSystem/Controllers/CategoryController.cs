using Microsoft.AspNetCore.Mvc;
using HelpSystem.Infrastructure.Services;
using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Infrastructure.Services.ArticleServices.Requests;
using HelpSystem.Models.ViewModels;
using HelpSystem.Models;

namespace HelpSystem.Controllers
{
    public class CategoryController : Controller
    {
        IRequestSender _sender;

        public CategoryController(IRequestSender sender) => _sender = sender;

        public IActionResult Index(int id, string name)
        {
            var category = new Category()
            {
                Id = id,
                Name = name
            };

            var model = new CategoryViewModels()
            {
                Category = category,
                Subcategories = _sender.Send<GetCategoryChildsQuery, IEnumerable<Category>>
                                    (new GetCategoryChildsQuery() { Category = category }),
                Article = _sender.Send<GetArticleByCategoryQuery, Article>
                                    (new GetArticleByCategoryQuery() { Category = category })
            };

            return View(model);
        }
    }
}
