using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.ArticleServices.Requests
{
    public class EditArticleCommand : IRequest<Article>
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public int? CategoryId { get; set; }

    }
}
