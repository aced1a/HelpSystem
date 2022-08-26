using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.CategoryServices.Requests
{
    public class CreateCategoryCommand : IRequest<Category>
    { 
        public string Name { get; set; }
        public Category Parent { get; set; }
    }
}
