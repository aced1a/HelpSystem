using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.ArticleServices.Requests
{
    public class CreateArticleCommand : IRequest<Article>
    {
        public string? Body { get; set; }
        public Category Category { get; set; }
    }
}
