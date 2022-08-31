using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpSystem.Infrastructure.Services.CategoryServices
{
    public class GetMainCategoriesQueryHandler : IRequestHandler<GetMainCategoriesQuery, IEnumerable<Category>>
    {
        ApplicationDbContext _context;

        public GetMainCategoriesQueryHandler(ApplicationDbContext context) => _context = context;

        public IEnumerable<Category> Handle(GetMainCategoriesQuery request)
        {
            return _context.Categories
                .AsNoTracking()
                .Where(c => c.Parent == null).ToArray();
        }
    }
}
