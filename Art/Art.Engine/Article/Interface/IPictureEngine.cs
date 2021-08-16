using Art.Engine.Article.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Art.Engine.Article.Interface
{
    public interface IPictureEngine
    {
        Task<List<PictureModelEngine>> GetAllAsync(int skipCount, int takeCount);
        Task<PictureModelEngine> GetAsync(int id);
        Task<IResultEngine> AddAsync(PictureModelEngine picture);
        Task<IResultEngine> UpdateAsync(PictureModelEngine picture);
        Task<IResultEngine> DeleteAsync(PictureModelEngine picture);
        Task<PictureModelEngine> GetLastAsunc();
    }
}
