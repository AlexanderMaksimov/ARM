using Art.DataAccess.Article.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Art.DataAccess.Article.Interface
{
    public interface IPictureDataAccess
    {
        Task<List<Pictures>> GetAllAsync(int skipCount, int takeCount);
        Task<Pictures> GetAsync(int id);
        Task<IResult> AddAsync(Pictures picture);
        Task<IResult> UpdateAsync(Pictures picture);
        Task<IResult> DeleteAsync(Pictures picture);
        Task<Pictures> GetLastAsunc();
    }
}
