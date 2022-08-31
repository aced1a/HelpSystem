using HelpSystem.Models;

namespace HelpSystem.Infrastructure.Services.ArticleServices.Requests
{
    public class GetArticleByCategoryQuery : IRequest<Article>
    {
        public Category Category { get; set; }
    }
}
