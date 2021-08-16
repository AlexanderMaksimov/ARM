using Art.DataAccess.Article.Interface;
using Art.Engine.Article.Interface;
using Art.Engine.Article.Models;
using Art.Engine.Infrastructure;
using AutoMapper;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Art.DataAccess.Article.Models;
using Art.DataAccess.Article.Implementation;


namespace Art.Engine.Article.Implementation
{
    public class FilesEngine : IFilesEngine
    {
        protected IFilesDataAccess FilesDA { get; set; }
        protected readonly ILogger Logger;
        protected IServiceProvider Provider { get; set; }
        protected readonly IMapper Mapper;
        public FilesEngine()
        {
            Provider = InitServiceProviderEngine.GetInstance().ServiceProvider;
            Logger = Provider.GetService<ILogger>();
            FilesDA = Provider.GetService<IFilesDataAccess>();
            Mapper = Provider.GetService<IMapper>();
        }
         public Task<List<FilesModelEngine>> GetAllAsync(int skipCount, int takeCount)
        {
            throw new NotImplementedException();
        }

        public Task<FilesModelEngine> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> AddAsync(FilesModelEngine file)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(FilesModelEngine file)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(FilesModelEngine file)
        {
            throw new NotImplementedException();
        }

        public Task<FilesModelEngine> GetLastAsunc()
        {
            throw new NotImplementedException();
        }
    }
   

}
