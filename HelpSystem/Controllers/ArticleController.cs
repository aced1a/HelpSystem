using Microsoft.AspNetCore.Mvc;
using HelpSystem.Infrastructure.Services;
using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Infrastructure.Services.ArticleServices.Requests;
using HelpSystem.Models.ViewModels;
using HelpSystem.Models;

namespace HelpSystem.Controllers
{
    public class ArticleController : Controller
    {
        IRequestSender _sender;

        public ArticleController(IRequestSender sender) => _sender = sender;

        [HttpGet]
        public IActionResult Edit(int categoryId) 
        {
            var category = new Category() { Id = categoryId };

            var article = _sender.Send<GetArticleByCategoryQuery, Article>
                (new GetArticleByCategoryQuery() { Category = category });

            if(article == null)
            {
                article = _sender.Send<CreateArticleCommand, Article>
                    (new CreateArticleCommand() { Category = category });
            }

            var model = new EditArticleViewModel()
            {
                Article = article
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(string name, int? parentId) 
        {
            Category result = _sender.Send<CreateCategoryCommand, Category>
                (new CreateCategoryCommand() { Name = name, ParentId =  parentId });

            return RedirectToAction(nameof(Edit), new { categoryId = result.Id });
        }

        [HttpPost]
        public IActionResult Save(int id, int categoryId, string body) 
        {
            var article = _sender.Send<EditArticleCommand, Article>
                (new EditArticleCommand() { Id = id, Body = body, CategoryId = categoryId });

            return RedirectToAction(nameof(Edit), new { categoryId = article.CategoryId });
        }

        [HttpPost]
        public IActionResult Delete(int categoryId) 
        {
            var category = _sender.Send<DeleteCategoryCommand, Category>
                (new DeleteCategoryCommand() { Id = categoryId });

            return RedirectToRoute("");
        }
    }
}
