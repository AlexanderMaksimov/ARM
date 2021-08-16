using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
//using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;
using Art.Engine.Article.Interface;
using Art.Engine.Article.Models;
using Art.Engine.User.Models;
using Art.DataAccess.Article.Interface;
using IResultEngine = Art.Engine.Article.Interface.IResultEngine;
using ResultEngine = Art.Engine.Article.Interface.ResultEngine;
using Art.Engine.Infrastructure;
using AutoMapper;
using Art.DataAccess.Article.Models;
using Art.DataAccess.User.Models;

namespace Art.Engine.Article.Implementation
{
    public class ArtikleEngine : IArtikleEngine
    {
        protected IArtikleDataAccess ArtikleDA { get; set; }
        protected readonly ILogger Logger;
        protected IServiceProvider Provider { get; set; }
        protected readonly IMapper Mapper;     
        public ArtikleEngine()
        {
            Provider = InitServiceProviderEngine.GetInstance().ServiceProvider;
            Logger = Provider.GetService<ILogger>();
            ArtikleDA = Provider.GetService<IArtikleDataAccess>();
            Mapper = Provider.GetService<IMapper>();
            //{ Name = "ILoggerFactory" Id = "Microsoft.Extensions.Logging.ILoggerFactory"}
        }
        public ArtikleEngine(ILogger logger, IMapper mapper, IArtikleDataAccess artikleDataAccess)
        {
            Logger = logger;
            Mapper = mapper;
            ArtikleDA = artikleDataAccess;
            //{ Name = "ILoggerFactory" Id = "Microsoft.Extensions.Logging.ILoggerFactory"}
        }
        public async Task<List<ArticleModelEngine>> GetAllAsync(int skipCount, int takeCount)
        {
            try
            {
                //проверка доступности для пользователя 
                var dbArtikles = await ArtikleDA.GetAllAsync(skipCount, takeCount);
                var articles = Mapper.Map<List<ArticleModelEngine>>(dbArtikles);
                return await Task.FromResult(articles);

            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<ArticleModelEngine> GetAsync(int id)
        {
            try
            {
                var dbArtikle = await ArtikleDA.GetAsync(id);
                var article = Mapper.Map<ArticleModelEngine>(dbArtikle);
                return await Task.FromResult(article);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<ArticleModelEngine> GetLastAsunc()
        {
            try
            {
                var dbArtikle = await ArtikleDA.GetLastAsunc();
                var article = Mapper.Map<ArticleModelEngine>(dbArtikle);
                return await Task.FromResult(article);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }

        }

        public async Task<IResultEngine> UpdateAsync(ArticleModelEngine article)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:article={article?.Name}");
                var dbArtikle = Mapper.Map<Articles>(article);
                var res = await ArtikleDA.UpdateAsync(dbArtikle);
                var result = Mapper.Map<IResultEngine>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(ResultEngine.Fail());
            }
        }

        public async Task<IResultEngine> AddAsync(ArticleModelEngine article)
        {
            // throw new NotImplementedException();
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:article={article?.Name}");
                var dbArtikle = Mapper.Map<Articles>(article);
                var res = await ArtikleDA.AddAsync(dbArtikle);
                var result = Mapper.Map<IResultEngine>(res);
                return await Task.FromResult(result);

            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(ResultEngine.Fail());
            }
        }

        public async Task<IResultEngine> DeleteAsync(ArticleModelEngine article)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:articleId={article?.Name}");
                var dbArtikle = Mapper.Map<Articles>(article);
                var res = await ArtikleDA.DeleteAsync(dbArtikle);
                var result = Mapper.Map<IResultEngine>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(ResultEngine.Fail());
            }
            // throw new NotImplementedException();
        }

    }
}
