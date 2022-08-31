using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.CategoryServices.Requests
{
    public class GetCategoryFullNameQuery : IRequest<IEnumerable<Category>>
    {
        public int Id { get; set; }
    }
}
