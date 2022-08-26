using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.CategoryServices
{
    public class GetCategoryChildsService : IRequestHandler<GetCategoryChildsQuery, IEnumerable<Category>>
    {
        ApplicationDbContext _context;
        public GetCategoryChildsService(ApplicationDbContext context) => _context = context;

        public IEnumerable<Category> Handle(GetCategoryChildsQuery request)
        {
            var category = _context.Categories.Find(request.Category.Id);

            return category.Childs?.ToArray();
        }

        public Task<IEnumerable<Category>> HandleAsync(GetCategoryChildsQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
