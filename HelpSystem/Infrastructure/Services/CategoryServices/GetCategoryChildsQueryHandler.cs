using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpSystem.Infrastructure.Services.CategoryServices
{
    public class GetCategoryChildsQueryHandler : IRequestHandler<GetCategoryChildsQuery, IEnumerable<Category>>
    {
        ApplicationDbContext _context;
        public GetCategoryChildsQueryHandler(ApplicationDbContext context) => _context = context;

        public IEnumerable<Category> Handle(GetCategoryChildsQuery request)
        {
            var category = _context.Categories.AsNoTracking()
                .Include(category => category.Childs)
                .FirstOrDefault(c => c.Id == request.Category.Id);

            if (category == null)
                throw new NullReferenceException();

            return category?.Childs;
        }
    }
}
