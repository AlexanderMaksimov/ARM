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
using Serilog;
using System.Reflection;

namespace Art.DataAccess.Article.Implementation
{
    public class FindArtikleDataAccess: IFindArtikleDataAccess
    {
        protected IServiceProvider _provider { get; set; }
        protected readonly ILogger _logger;
        protected readonly ArticleDbContext _dbContext;

        public FindArtikleDataAccess()
        {
            _provider = InitServiceProviderDA.GetInstance().ServiceProvider;
            _dbContext = _provider.GetService<ArticleDbContext>();
            _logger = _provider.GetService<ILogger>();
        }

        public async Task<List<Articles>> FindAsync(string text)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:text={text}");
                var dbArticle = await _dbContext.Articles.Include(sc => sc.Author)
                    .Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
                    .Include(c => c.UserArticle).ThenInclude(sc => sc.Article)
                    .Where(z => EF.Functions.Like(z.Name.ToLower(), $"%{text.ToLower()}%") ||
                               EF.Functions.Like(z.Description.ToLower(), $"%{text.ToLower()}%") ||
                               EF.Functions.Like(z.Context.ToLower(), $"%{text.ToLower()}%")).ToListAsync();
                //Where(x =>(x.Description.Contains(text) || x.Context.Contains(text) || x.Name.Contains(text)));
                //var dbArticle2 = await _dbContext.Articles.Include(c => c.AuthorArticle).ThenInclude(sc => sc.Author)
                //.Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
                //.Include(c => c.UserArticle).ThenInclude(sc => sc.Article).Where(x => (x.Description.Contains(text) || x.Context.Contains(text) || x.Name.Contains(text))).ToListAsync();
                return dbArticle;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error :{ex.ToString()}");
                return null;
            }

        }
        public async Task<List<Articles>> FindByNameAsync(string text)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:text={text}");
                var dbArticle = await _dbContext.Articles.Include(sc => sc.Author)
                    .Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
                    .Include(c => c.UserArticle).ThenInclude(sc => sc.Article)
                    .Where(z => EF.Functions.Like(z.Name.ToLower(), $"%{text.ToLower()}%")).ToListAsync();               
                return dbArticle;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error :{ex.ToString()}");
                return null;
            }

        }

        public async Task<List<Articles>> FindByDescriptionAsync(string text)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:text={text}");
                var dbArticle = await _dbContext.Articles.Include(sc => sc.Author)
                    .Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
                    .Include(c => c.UserArticle).ThenInclude(sc => sc.Article)
                    .Where(z => EF.Functions.Like(z.Description.ToLower(), $"%{text.ToLower()}%")).ToListAsync();
                return dbArticle;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error :{ex.ToString()}");
                return null;
            }
            //   throw new NotImplementedException();
        }

        public async Task<List<Articles>> FindByContextAsync(string text)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:text={text}");
                var dbArticle = await _dbContext.Articles.Include(sc => sc.Author)
                    .Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
                    .Include(c => c.UserArticle).ThenInclude(sc => sc.Article)
                    .Where(z => EF.Functions.Like(z.Context.ToLower(), $"%{text.ToLower()}%")).ToListAsync();
                return dbArticle;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error :{ex.ToString()}");
                return null;
            }
        }

        public async Task<List<Articles>> FindByAuthorAsync(string text)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:text={text}");
                //List<Articles> articles = new List<Articles>();
                var dbArticles = await _dbContext.Articles.Include(sc => sc.Author)
                    .Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
                    .Include(c => c.UserArticle).ThenInclude(sc => sc.Article)
                    .Where(x => EF.Functions.Like(x.Author.User.UserName.ToLower(), $"%{text.ToLower()}%")).ToListAsync();
                //.Select(z => (z.Author.Where(x => EF.Functions.Like(x.Author.User.UserName.ToLower(), $"%{text.ToLower()}%"))).Select(x => x.Article)).ToListAsync();
                    //foreach (var article in dbArticles)
                    //{
                    //    articles.Add(article);
                    //}
                
                return dbArticles;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error :{ex.ToString()}");
                return null;
            }
            //throw new NotImplementedException();
        }

        public async Task<List<Articles>> FindByTopicNameAsync(string text)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:text={text}");
                List<Articles> articles = new List<Articles>();
                var dbArticles = await _dbContext.Articles.Include(sc => sc.Author)
                    .Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
                    .Include(c => c.UserArticle).ThenInclude(sc => sc.Article)
                    .Select(z => (z.TopicArticle.Where(x => EF.Functions.Like(x.Topic.Name.ToLower(), $"%{text.ToLower()}%"))).Select(x => x.Article)).ToListAsync();
                foreach (var dbArticle in dbArticles)
                {
                    foreach (var article in dbArticle)
                    {
                        articles.Add(article);
                    }
                }
                return articles;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error :{ex.ToString()}");
                return null;
            }
            //throw new NotImplementedException();
        }
        public async Task<List<Articles>> FindByTopicIdAsync(int id)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:text={id}");
                List<Articles> articles = new List<Articles>();
                var dbArticles = await _dbContext.Articles.Include(sc => sc.Author)
                    .Include(c => c.TopicArticle).ThenInclude(sc => sc.Topic)
                    .Include(c => c.UserArticle).ThenInclude(sc => sc.Article)
                    .Select(z => (z.TopicArticle.Where(x => x.TopicId==id).Select(x => x.Article))).ToListAsync();
                foreach (var dbArticle in dbArticles)
                {
                    foreach (var article in dbArticle)
                    {
                        articles.Add(article);
                    }
                }
                return articles;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error :{ex.ToString()}");
                return null;
            }
            //throw new NotImplementedException();
        }
    }
}
