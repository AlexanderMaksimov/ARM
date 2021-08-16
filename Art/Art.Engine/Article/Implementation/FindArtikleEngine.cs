using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Serilog;
using System.Reflection;
using Art.Engine.Article.Interface;
using Art.Engine.Article.Models;
using Art.Engine.Infrastructure;
using AutoMapper;
using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;

namespace Art.Engine.Article.Implementation
{
    public class FindArtikleEngine : IFindArtikleEngine
    {
        protected IServiceProvider Provider { get; set; }
        protected readonly ILogger Logger;
        protected IMapper Mapper { get; set; }
        protected IFindArtikleDataAccess FindArtikleDataAccess { get; set; }
        public FindArtikleEngine()
        {
            Provider = InitServiceProviderEngine.GetInstance().ServiceProvider;
            Logger = Provider.GetService<ILogger>();
            FindArtikleDataAccess = Provider.GetService<IFindArtikleDataAccess>();
            Mapper = Provider.GetService<IMapper>();
        }

        public async Task<List<ArticleModelEngine>> FindAsync(string text)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:Find text={text}");
                var res = await FindArtikleDataAccess.FindAsync(text);
                var result = Mapper.Map<List<ArticleModelEngine>>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }

        }
        public async Task<List<ArticleModelEngine>> FindByNameAsync(string text)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:Find text={text}");
                var res = await FindArtikleDataAccess.FindByNameAsync(text);
                var result = Mapper.Map<List<ArticleModelEngine>>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }

        }

        public async Task<List<ArticleModelEngine>> FindByDescriptionAsync(string text)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:Find text={text}");
                var res = await FindArtikleDataAccess.FindByDescriptionAsync(text);
                var result = Mapper.Map<List<ArticleModelEngine>>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<List<ArticleModelEngine>> FindByContextAsync(string text)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:Find text={text}");
                var res = await FindArtikleDataAccess.FindByDescriptionAsync(text);
                var result = Mapper.Map<List<ArticleModelEngine>>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<List<ArticleModelEngine>> FindByAuthorAsync(string text)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:Find text={text}");
                var res = await FindArtikleDataAccess.FindByAuthorAsync(text);
                var result = Mapper.Map<List<ArticleModelEngine>>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<List<ArticleModelEngine>> FindByTopicNameAsync(string text)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:Find text={text}");
                var res = await FindArtikleDataAccess.FindByTopicNameAsync(text);
                var result = Mapper.Map<List<ArticleModelEngine>>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }
        public async Task<List<ArticleModelEngine>> FindByTopicIdAsync(int id)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:Find text={id}");
                var res = await FindArtikleDataAccess.FindByTopicIdAsync(id);
                var result = Mapper.Map<List<ArticleModelEngine>>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }
    }
}
