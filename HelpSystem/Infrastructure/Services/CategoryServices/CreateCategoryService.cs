using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.CategoryServices
{
    public class CreateCategoryService : IRequestHandler<CreateCategoryCommand, Category>
    {
        ApplicationDbContext _context;

        public CreateCategoryService(ApplicationDbContext context) => _context = context;

        public Category Handle(CreateCategoryCommand request)
        {
            var category = new Category() {
                Name = request.Name,
                Parent = request.Parent
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        public Task<Category> HandleAsync(CreateCategoryCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
