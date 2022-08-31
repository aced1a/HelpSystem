using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.ArticleServices.Requests
{
    public class GetArticleCommand : IRequest<Article>
    {
        public int Id { get; set; }
    }
}
