using Art.DataAccess.Article.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Art.DataAccess.Article.Interface
{
    public interface ITopicDataAccess
    {
        Task<List<Topics>> GetAllAsync();
        Task<Topics> GetAsync(int id);
        Task<Topics> GetFirstAsunc();
        Task<IResult> AddAsync(Topics article);
        Task<IResult> UpdateAsync(Topics topic);
        Task<IResult> DeleteAsync(Topics topic);
    }
}
