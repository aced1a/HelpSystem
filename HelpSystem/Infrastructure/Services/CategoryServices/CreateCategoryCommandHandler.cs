using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpSystem.Infrastructure.Services.CategoryServices
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Category>
    {
        ApplicationDbContext _context;

        public CreateCategoryCommandHandler(ApplicationDbContext context) => _context = context;

        public Category Handle(CreateCategoryCommand request)
        {
            var category = new Category() {
                Id = null,
                Name = request.Name,
                ParentId = request.ParentId
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }
    }
}
