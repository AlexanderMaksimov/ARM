using Art.DataAccess.Article.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Art.DataAccess.Article.Interface
{
    public interface IFindArtikleDataAccess
    {
        Task<List<Articles>> FindAsync(string text);
        Task<List<Articles>> FindByNameAsync(string text);
        Task<List<Articles>> FindByDescriptionAsync(string text);
        Task<List<Articles>> FindByContextAsync(string text);
        Task<List<Articles>> FindByAuthorAsync(string text);
        Task<List<Articles>> FindByTopicNameAsync(string text);
        Task<List<Articles>> FindByTopicIdAsync(int id);
    }
}
