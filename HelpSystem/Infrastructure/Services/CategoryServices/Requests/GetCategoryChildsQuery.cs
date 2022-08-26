using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.CategoryServices.Requests
{
    public class GetCategoryChildsQuery : IRequest<IEnumerable<Category>>
    {
        public Category Category { get; set; }
    }
}
