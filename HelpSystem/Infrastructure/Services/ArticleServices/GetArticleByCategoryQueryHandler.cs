using HelpSystem.Infrastructure.Services.ArticleServices.Requests;
using HelpSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpSystem.Infrastructure.Services.ArticleServices
{
    public class GetArticleByCategoryQueryHandler : IRequestHandler<GetArticleByCategoryQuery, Article>
    {
        ApplicationDbContext _context;

        public GetArticleByCategoryQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Article Handle(GetArticleByCategoryQuery request)
        {
            var category = _context.Categories.Find(request.Category.Id);


            if (category == null)
                throw new NullReferenceException();

            return  _context.Articles
                .AsNoTracking()
                .Include(a => a.Category)
                .FirstOrDefault(a => a.CategoryId == category.Id);
        }

    }
}
