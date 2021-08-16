using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Art.DataAccess.User.Models;
//using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;

namespace Art.DataAccess.Article.Implementation
{
    public class ArtikleDataAccess : IArtikleDataAccess
    {
        protected IServiceProvider _provider;
        protected readonly ILogger _logger;

        protected readonly ArticleDbContext _dbContext;
        public ArtikleDataAccess()
        {
            _provider = InitServiceProviderDA.GetInstance().ServiceProvider;
            _dbContext = _provider.GetService<ArticleDbContext>();
            _logger = _provider.GetService<ILogger>();
            //{ Name = "ILoggerFactory" Id = "Microsoft.Extensions.Logging.ILoggerFactory"}
        }

        public async Task<List<Articles>> GetAllAsync(int skipCount, int takeCount)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:count={skipCount}");
                var dbArticles = await _dbContext.Articles.Include(sc => sc.Author)
.Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
.Include(c => c.UserArticle).ThenInclude(sc => sc.Article).OrderByDescending(z => z.CreateDateTime).Skip(skipCount).Take(takeCount).ToListAsync();
                //await _dbContext.Users.Take(count).ToListAsync();
                //dbArticles.ToArray();
                //Console.WriteLine(dbArticles.Count);
                return dbArticles;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<Articles> GetAsync(int id)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:id={id}");
                var dbArticle = await _dbContext.Articles.Include(sc => sc.Author)
                 .Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
                 .Include(c => c.UserArticle).ThenInclude(sc => sc.Article).FirstOrDefaultAsync(m => m.ArticleId == id);
                //var authorsArticle = dbArticle.AuthorArticle.Select(z => z.Author.User.UserName).ToArray();
                //string authors = string.Join(',', authorsArticle);
                // var topicsArticle = dbArticle.TopicArticle.Select(z => z.Topic.Name).ToArray();
                //string topics = string.Join(',', topicsArticle);
                // var userArticle = dbArticle.UserArticle.Select(z => z.Article.Name).ToArray();
                return dbArticle;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return null;
            }

        }
        public async Task<Articles> GetLastAsunc()
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} ");
                var dbArticle = await _dbContext.Articles.Include(sc => sc.Author)
                 .Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
                 .Include(c => c.UserArticle).ThenInclude(sc => sc.Article).OrderByDescending(z => z.ArticleId).FirstOrDefaultAsync();
                // _dbContext.Topics.OrderByDescending(z => z.TopicId).FirstAsync();
                return dbArticle;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }
        public async Task<IResult> UpdateAsync(Articles article)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:articleId={article.ArticleId}");
                //throw new NotImplementedException();
                var currentArticle = _dbContext.Articles.FirstOrDefaultAsync(z => z.ArticleId == article.ArticleId).Result;
                if (currentArticle == null)
                {
                    return await Task.FromResult(Result.Fail());
                }
                currentArticle.Context = article.Context;
                currentArticle.Description = article.Description;
                currentArticle.Name = article.Name;
                currentArticle.UpdateDateTime = article.UpdateDateTime;
                currentArticle.StatusPublication = article.StatusPublication;
                currentArticle.StatusVisibleUser = article.StatusVisibleUser;

                currentArticle.TopicArticle = article.TopicArticle;
                _dbContext.Articles.Update(currentArticle);
                int result = await _dbContext.SaveChangesAsync();
                if (result > 0)
                    return await Task.FromResult(Result.Success());
                else
                    return await Task.FromResult(Result.Success("not update"));
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(Result.Fail());
            }
        }

        public async Task<IResult> AddAsync(Articles article)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} " +
                                    $"Parametrs:articleId={article.ArticleId}");
                var currentArticle = _dbContext.Articles.FirstOrDefaultAsync(z => z.ArticleId == article.ArticleId).Result;

                //заменить на процедуру добавления в sql 
                _dbContext.Articles.Add(article);
                await _dbContext.SaveChangesAsync();
                //List<AuthorArticle> authors = new List<AuthorArticle>();
                //если запись параллельна что тогда 

                int id = _dbContext.Articles.MaxAsync(x => x.ArticleId).Result;
                // не нужно 
                return await Task.FromResult(Result.Success());

            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(Result.Fail());
            }
        }

        public async Task<IResult> DeleteAsync(Articles article)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:articleId={article.ArticleId}");
                var currentArticle = _dbContext.Articles.FirstOrDefaultAsync(z => z.ArticleId == article.ArticleId).Result;
                if (currentArticle == null)
                    return await Task.FromResult(Result.Fail("Not found"));
                _dbContext.Articles.Remove(currentArticle);
                var result = await _dbContext.SaveChangesAsync();
                if (result >= 0)
                    return await Task.FromResult(Result.Success());
                else
                    return await Task.FromResult(Result.Fail());
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(Result.Fail());
            }
            // throw new NotImplementedException();
        }

    }
}
