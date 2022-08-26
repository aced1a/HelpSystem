using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.CategoryServices
{
    public class GetMainCategoriesService : IRequestHandler<GetMainCategoriesQuery, IEnumerable<Category>>
    {
        ApplicationDbContext _context;

        public GetMainCategoriesService(ApplicationDbContext context) => _context = context;

        public IEnumerable<Category> Handle(GetMainCategoriesQuery request)
        {
            return _context.Categories.Where(c => c.Parent == null).ToArray();
        }

        public Task<IEnumerable<Category>> HandleAsync(GetMainCategoriesQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
