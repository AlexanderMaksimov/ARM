using Art.Engine.Article.Models;
using Art.Engine.User.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Art.Engine.Article.Interface
{
    public interface IArtikleEngine
    {       
        Task<List<ArticleModelEngine>> GetAllAsync(int skipCount, int takeCount);
        Task<ArticleModelEngine> GetAsync(int id);       
        Task<IResultEngine> AddAsync(ArticleModelEngine article);
        Task<IResultEngine> UpdateAsync(ArticleModelEngine article);
        Task<IResultEngine> DeleteAsync(ArticleModelEngine article);
        Task<ArticleModelEngine> GetLastAsunc();
    }
    
}
