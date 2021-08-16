using Art.DataAccess.Article.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Art.DataAccess.Article.Interface
{
    public interface IFilesDataAccess
    {
        Task<List<Files>> GetAllAsync(int skipCount, int takeCount);
        Task<Files> GetAsync(int id);
        Task<IResult> AddAsync(Files file);
        Task<IResult> UpdateAsync(Files file);
        Task<IResult> DeleteAsync(Files file);
        Task<Files> GetLastAsunc();
    }
}
