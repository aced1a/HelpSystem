using HelpSystem.Infrastructure.Services.ArticleServices.Requests;
using HelpSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpSystem.Infrastructure.Services.ArticleServices
{
    public class EditArticleCommandHandler : IRequestHandler<EditArticleCommand, Article>
    {
        ApplicationDbContext _context;

        public EditArticleCommandHandler(ApplicationDbContext context) => _context = context;

        public Article Handle(EditArticleCommand request)
        {
            var article = _context.Articles.Find(request.Id);

            if (article == null) throw new NullReferenceException();

            article.Body = request.Body;
            article.CategoryId = request.CategoryId ?? article.CategoryId;

            _context.SaveChanges();

            return article;
        }
    }
}
