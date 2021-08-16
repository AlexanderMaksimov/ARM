using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
using System.Reflection;
using Serilog;

namespace Art.DataAccess.Article.Implementation
{
    public class TopicDataAccess : ITopicDataAccess
    {
        protected IServiceProvider _provider { get; set; }
        protected readonly ILogger _logger;

        protected readonly ArticleDbContext _dbContext;
        public TopicDataAccess()
        {
            _provider = InitServiceProviderDA.GetInstance().ServiceProvider;
            _dbContext = _provider.GetService<ArticleDbContext>();
            _logger = _provider.GetService<ILogger>();
        }
        public async Task<List<Topics>> GetAllAsync()
        {
            try
            {
                var topics =await _dbContext.Topics.ToListAsync();
                return topics;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Topics> GetAsync(int id)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:id={id}");
                var topics = await _dbContext.Topics.FirstOrDefaultAsync(z => z.TopicId == id);
                return topics;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return null;
            }
            //throw new NotImplementedException();
        }
        public async Task<Topics> GetFirstAsunc()
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName}");
                var topics = await _dbContext.Topics.FirstOrDefaultAsync();
                //var lastBill = purchaseBills.Where(f => f.BillID == purchaseBills.Max(f2 => f2.BillID)).FirstOrDefault();
                return topics;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }
        public async Task<IResult> AddAsync(Topics topic)
        {
            try
            {
                if (topic == null)
                    return await Task.FromResult(Result.Fail("topic null"));
                _dbContext.Topics.Add(topic);
                int result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                    return await Task.FromResult(Result.Success());
                else
                    return await Task.FromResult(Result.Fail("Not Create"));
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(Result.Fail("Not Create"));
            }
            //throw new NotImplementedException();
        }

        public async Task<IResult> UpdateAsync(Topics topic)
        {
            try
            {
                //проверить 
                if( topic?.TopicId==null)
                    return await Task.FromResult(Result.Fail("id null"));
                var currentTopic = _dbContext.Topics.FirstOrDefaultAsync(z => z.TopicId == topic.TopicId).Result;
                //if (currentTopic == null)
                //{
                //    return await AddAsync(topic);
                //}
                //else
                //{
                    currentTopic.Name = topic?.Name;
                    currentTopic.TopicArticle = topic?.TopicArticle;
                    currentTopic.Description = topic?.Description;
                    int result = await _dbContext.SaveChangesAsync();
                    if (result >= 0)
                        return await Task.FromResult(Result.Success());
                    else
                        return await Task.FromResult(Result.Success("Not Update"));
                //}
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(Result.Fail("Not Update"));
            }
            //throw new NotImplementedException();

        }

        public async Task<IResult> DeleteAsync(Topics topic)
        {
            try
            {
                var dbTopic = _dbContext.Topics.FirstOrDefaultAsync(z => z.TopicId == topic.TopicId).Result;
                if (dbTopic == null)
                    return await Task.FromResult(Result.Fail("Not find id"));
                _dbContext.Remove(dbTopic);
                int result = await _dbContext.SaveChangesAsync();
                if (result >= 0 )
                    return await Task.FromResult(Result.Success());
                else
                    return await Task.FromResult(Result.Fail("Not Delete"));
                // return await (result > 0 ? Task.FromResult(Result.Success()) : Task.FromResult(Result.Fail("Not Delete")));
                //throw new NotImplementedException();
            }
            catch (Exception ex) 
            {
                _logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(Result.Fail("Exception"));
            }

        }
    }
}
