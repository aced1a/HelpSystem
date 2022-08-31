using HelpSystem.Infrastructure.Services.CategoryServices.Requests;
using HelpSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpSystem.Infrastructure.Services.CategoryServices
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Category>
    {
        ApplicationDbContext _context;

        public DeleteCategoryCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Category Handle(DeleteCategoryCommand request)
        {
            var category = _context.Categories.Find(request.Id);

            if (category == null) throw new NullReferenceException();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return category;
        }
    }
}
