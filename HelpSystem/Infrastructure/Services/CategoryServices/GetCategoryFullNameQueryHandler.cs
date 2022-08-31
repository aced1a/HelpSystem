using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpSystem.Infrastructure.Services.CategoryServices
{
    public class GetCategoryFullNameQueryHandler : IRequestHandler<GetCategoryFullNameQuery, IEnumerable<Category>>
    {
        ApplicationDbContext _context;

        public GetCategoryFullNameQueryHandler(ApplicationDbContext context) => _context = context;

        public IEnumerable<Category> Handle(GetCategoryFullNameQuery request)
        {
            var categories = new List<Category>();

            var category = _context.Categories//.AsNoTracking()
                                //.Include(c => c.Parent)
                                .FirstOrDefault(c => c.Id == request.Id);

            if (category == null) throw new NullReferenceException();

            while(category != null)
            {
                categories.Add(category);
                _context.Entry(category).Reference(c => c.Parent).Load();

                category = category.Parent;
            }

            return categories;
        }
    }
}
