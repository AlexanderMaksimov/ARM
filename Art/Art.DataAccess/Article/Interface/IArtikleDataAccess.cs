using Art.DataAccess.Article.Implementation;
using Art.DataAccess.Article.Models;
using Art.DataAccess.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Art.DataAccess.Article.Interface
{
    public interface IArtikleDataAccess
    {       
        Task<List<Articles>> GetAllAsync(int skipCount, int takeCount);
        Task<Articles> GetAsync(int id);       
        Task<IResult> AddAsync(Articles article);
        Task<IResult> UpdateAsync(Articles article);
        Task<IResult> DeleteAsync(Articles article);
        Task<Articles> GetLastAsunc();
    }
    
}
