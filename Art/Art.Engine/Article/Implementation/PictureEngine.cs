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
    public class PictureEngine : IPictureEngine
    {
        protected IPictureDataAccess PictureDA { get; set; }
        protected readonly ILogger Logger;
        protected IServiceProvider Provider { get; set; }
        protected readonly IMapper Mapper;
        public PictureEngine()
        {
            Provider = InitServiceProviderEngine.GetInstance().ServiceProvider;
            Logger = Provider.GetService<ILogger>();
            PictureDA = Provider.GetService<IPictureDataAccess>();
            Mapper = Provider.GetService<IMapper>();
        }

        public async Task<List<Models.PictureModelEngine>> GetAllAsync(int skipCount, int takeCount)
        {
            try
            {
                var dbArtikles = await PictureDA.GetAllAsync(skipCount, takeCount);
                var articles = Mapper.Map<List<PictureModelEngine>>(dbArtikles);
                return await Task.FromResult(articles);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<Models.PictureModelEngine> GetAsync(int id)
        {
            try
            {
                var dbArtikles = await PictureDA.GetAsync(id);
                var article = Mapper.Map<PictureModelEngine>(dbArtikles);
                return await Task.FromResult(article);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<Models.PictureModelEngine> GetLastAsunc()
        {
            try
            {
                var dbArtikles = await PictureDA.GetLastAsunc();
                var article = Mapper.Map<PictureModelEngine>(dbArtikles);
                return await Task.FromResult(article);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }
        public async Task<IResultEngine> AddAsync(Models.PictureModelEngine picture)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:article={picture?.Id}");
                var dbArtikle = Mapper.Map<Pictures>(picture);
                var res = await PictureDA.AddAsync(dbArtikle);
                var result = Mapper.Map<IResultEngine>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(ResultEngine.Fail());
            }
        }

        public async Task<IResultEngine> DeleteAsync(Models.PictureModelEngine picture)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:article={picture?.Id}");
                var dbArtikle = Mapper.Map<Pictures>(picture);
                var res = await PictureDA.DeleteAsync(dbArtikle);
                var result = Mapper.Map<IResultEngine>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(ResultEngine.Fail());
            }
        }
        public async Task<IResultEngine> UpdateAsync(Models.PictureModelEngine picture)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:article={picture?.Id}");
                var dbArtikle = Mapper.Map<Pictures>(picture);
                var res = await PictureDA.UpdateAsync(dbArtikle);
                var result = Mapper.Map<IResultEngine>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(ResultEngine.Fail());
            }
        }
    }
}
