
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
//using Microsoft.Extensions.Logging;
using System.Reflection;
using Serilog;
using Art.Engine.Article.Interface;
using Art.Engine.Article.Models;
using Art.Engine.Infrastructure;
using AutoMapper;
using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;

namespace Art.Engine.Article.Implementation
{
    public class TopicEngine : ITopicEngine
    {
        protected IServiceProvider Provider { get; set; }
        protected readonly ILogger Logger;
        protected IMapper Mapper { get; set; }
        protected ITopicDataAccess TopicDataAccess { get; set; }
        public TopicEngine()
        {
            Provider = InitServiceProviderEngine.GetInstance().ServiceProvider;
            Logger = Provider.GetService<ILogger>();
            TopicDataAccess = Provider.GetService<ITopicDataAccess>();
            Mapper = Provider.GetService<IMapper>();
        }
        public async Task<List<TopicModelEngine>> GetAllAsync()
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} ");
                var res = await TopicDataAccess.GetAllAsync();
                var result = Mapper.Map<List<TopicModelEngine>>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<TopicModelEngine> GetAsync(int id)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:id={id}");
                var res = await TopicDataAccess.GetAsync(id);
                var result = Mapper.Map<TopicModelEngine>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }
        public async Task<TopicModelEngine> GetFirstAsunc()
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} ");
                var res = await TopicDataAccess.GetFirstAsunc();
                var result = Mapper.Map<TopicModelEngine>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }
        public async Task<IResultEngine> UpdateAsync(TopicModelEngine topic)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:topic={topic.TopicId}");
                var dbTopic = Mapper.Map<Topics>(topic);
                var res = await TopicDataAccess.UpdateAsync(dbTopic);
                var result = Mapper.Map<IResultEngine>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(ResultEngine.Fail("Not Create"));
            }
            //throw new NotImplementedException();
        }

        public async Task<IResultEngine> AddAsync(TopicModelEngine topic)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:topic={topic.TopicId}");
                var dbTopic = Mapper.Map<Topics>(topic);
                var res = await TopicDataAccess.AddAsync(dbTopic);
                var result = Mapper.Map<IResultEngine>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(ResultEngine.Fail("Not Update"));
            }
            //throw new NotImplementedException();

        }

        public async Task<IResultEngine> DeleteAsync(TopicModelEngine topic)
        {
            try
            {
                Logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:topic={topic.TopicId}");
                var dbTopic = Mapper.Map<Topics>(topic);
                var res = await TopicDataAccess.DeleteAsync(dbTopic);
                var result = Mapper.Map<IResultEngine>(res);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(ResultEngine.Fail("Not Delete"));
            }
        }
    }
}
