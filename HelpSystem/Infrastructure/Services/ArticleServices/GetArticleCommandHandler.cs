using HelpSystem.Infrastructure.Services.ArticleServices.Requests;
using HelpSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpSystem.Infrastructure.Services.ArticleServices
{
    public class GetArticleCommandHandler : IRequestHandler<GetArticleCommand, Article>
    {
        ApplicationDbContext _context;

        public GetArticleCommandHandler(ApplicationDbContext context) => _context = context;

        public Article Handle(GetArticleCommand request)
        {
            var article = _context.Articles.AsNoTracking()
                .Include(a => a.Category)
                .FirstOrDefault(a => a.Id == request.Id);

            if (article == null) throw new NullReferenceException();

            return article;
        }
    }
}
