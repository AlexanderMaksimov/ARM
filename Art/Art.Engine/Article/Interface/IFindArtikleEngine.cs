using Art.Engine.Article.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Art.Engine.Article.Interface
{
    public interface IFindArtikleEngine
    {
        Task<List<ArticleModelEngine>> FindAsync(string text);
        Task<List<ArticleModelEngine>> FindByNameAsync(string text);
        Task<List<ArticleModelEngine>> FindByDescriptionAsync(string text);
        Task<List<ArticleModelEngine>> FindByContextAsync(string text);
        Task<List<ArticleModelEngine>> FindByAuthorAsync(string text);
        Task<List<ArticleModelEngine>> FindByTopicNameAsync(string text);
        Task<List<ArticleModelEngine>> FindByTopicIdAsync(int id);
    }
}
