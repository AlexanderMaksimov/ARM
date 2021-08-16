using Art.Engine.Article.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Art.Engine.Article.Interface
{
    public interface ITopicEngine
    {
        Task<List<TopicModelEngine>> GetAllAsync();
        Task<TopicModelEngine> GetAsync(int id);
        Task<TopicModelEngine> GetFirstAsunc();
        Task<IResultEngine> AddAsync(TopicModelEngine article);
        Task<IResultEngine> UpdateAsync(TopicModelEngine topic);
        Task<IResultEngine> DeleteAsync(TopicModelEngine topic);
    }
}
