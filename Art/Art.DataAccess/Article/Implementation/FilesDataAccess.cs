using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Art.DataAccess.Article.Implementation
{
    public class FilesDataAccess: IFilesDataAccess
    {
        protected IServiceProvider _provider;
        protected readonly ILogger _logger;

        protected readonly ArticleDbContext _dbContext;
        public FilesDataAccess()
        {
            _provider = InitServiceProviderDA.GetInstance().ServiceProvider;
            _dbContext = _provider.GetService<ArticleDbContext>();
            _logger = _provider.GetService<ILogger>();
        }

        public Task<List<Files>> GetAllAsync(int skipCount, int takeCount)
        {
            throw new NotImplementedException();
        }

        public Task<Files> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddAsync(Files file)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(Files file)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(Files file)
        {
            throw new NotImplementedException();
        }

        public Task<Files> GetLastAsunc()
        {
            throw new NotImplementedException();
        }
    }
}
