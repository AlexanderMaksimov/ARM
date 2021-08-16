
using Art.Engine.Article.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Art.DataAccess.Article.Interface
{
    public interface IFilesEngine
    {
        Task<List<FilesModelEngine>> GetAllAsync(int skipCount, int takeCount);
        Task<FilesModelEngine> GetAsync(int id);
        Task<IResult> AddAsync(FilesModelEngine file);
        Task<IResult> UpdateAsync(FilesModelEngine file);
        Task<IResult> DeleteAsync(FilesModelEngine file);
        Task<FilesModelEngine> GetLastAsunc();
    }
}
