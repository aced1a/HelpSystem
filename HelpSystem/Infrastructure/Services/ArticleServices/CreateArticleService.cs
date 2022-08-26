using HelpSystem.Infrastructure.Services.ArticleServices.Requests;
using HelpSystem.Models;
using System.Linq;

namespace HelpSystem.Infrastructure.Services.ArticleServices
{
    public class CreateArticleService : IRequestHandler<CreateArticleCommand, Article>
    {
        ApplicationDbContext _context;

        public CreateArticleService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public Article Handle(CreateArticleCommand request)
        {
            var article = new Article()
            {
                Body = request.Body,
                CreatedAt = DateTime.UtcNow
            };
            _context.Articles.Add(article);

            var category = _context.Categories.Find(request.Category.Id);

            if (category == null)
                throw new NotImplementedException();
            else
                category.Article = article;

            _context.SaveChanges();

            return article;
        }

        public async Task<Article> HandleAsync(CreateArticleCommand request)
        {
            var article = new Article()
            {
                Body = request.Body,
                CreatedAt = DateTime.UtcNow
            };
            await _context.Articles.AddAsync(article);

            var category = await _context.Categories.FindAsync(request.Category.Id);

            if (category == null)
                throw new NotImplementedException();
            else
                category!.Article = article;

            await _context.SaveChangesAsync();

            return article;
        }
    }
}
