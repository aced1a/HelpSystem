using Microsoft.AspNetCore.Mvc;
using HelpSystem.Infrastructure.Services;
using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Infrastructure.Services.ArticleServices.Requests;
using HelpSystem.Models.ViewModels;
using HelpSystem.Models;


namespace HelpSystem.Controllers
{
    public class APIController : Controller
    {
        IRequestSender _sender;

        public APIController(IRequestSender sender)
            => _sender = sender;

        public ActionResult GetSubcategories(int id, string name) 
        {
            var category = new Category() { Id = id, Name = name };

            return Json(
                _sender.Send<GetCategoryChildsQuery, IEnumerable<Category>>
                    (new GetCategoryChildsQuery() { Category = category })
            );
        }

        public ActionResult GetArticle(int categoryId) 
        {
            var category = new Category() { Id = categoryId };

            return Json(
                _sender.Send<GetArticleByCategoryQuery, Article>
                    (new GetArticleByCategoryQuery() { Category = category })
            );
        }

        public IActionResult GetCategoryFullName(int id) 
        {
            return ViewComponent("CategoryFullName", id);
        }
    }
}
