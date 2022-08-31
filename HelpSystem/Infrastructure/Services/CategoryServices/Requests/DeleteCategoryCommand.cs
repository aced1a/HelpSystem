using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.CategoryServices.Requests
{
    public class DeleteCategoryCommand : IRequest<Category>
    {
        public int Id { get; set; }
    }
}
