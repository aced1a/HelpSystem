using HelpSystem.Infrastructure.Services.ArticleServices.Requests;
using HelpSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpSystem.Infrastructure.Services.ArticleServices
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Article>
    {
        ApplicationDbContext _context;

        public CreateArticleCommandHandler(ApplicationDbContext context) 
        {
            _context = context;
        }

        public Article Handle(CreateArticleCommand request)
        {
            var article = new Article()
            {
                Id = null,
                Body = request.Body,
                CreatedAt = DateTime.UtcNow,
                CategoryId = request.Category.Id ?? 0
            };
            _context.Articles.Add(article);

            var category = _context.Categories.Find(request.Category.Id);

            if (category == null)
                throw new NullReferenceException();
            else
                category.Article = article;

            _context.SaveChanges();

            return article;
        }
    }
}
