
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
    public class PictureDataAccess : IPictureDataAccess
    {
        protected IServiceProvider _provider;
        protected readonly ILogger _logger;

        protected readonly ArticleDbContext _dbContext;
        public PictureDataAccess()
        {
            _provider = InitServiceProviderDA.GetInstance().ServiceProvider;
            _dbContext = _provider.GetService<ArticleDbContext>();
            _logger = _provider.GetService<ILogger>();
            //{ Name = "ILoggerFactory" Id = "Microsoft.Extensions.Logging.ILoggerFactory"}
        }

        public async Task<List<Pictures>> GetAllAsync(int skipCount, int takeCount)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:skipCount={skipCount} takeCount={takeCount}");
                var dbArticles = await _dbContext.Pictures.Skip(skipCount).Take(takeCount).ToListAsync();
                return dbArticles;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<Pictures> GetAsync(int id)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:name={id}");
                var dbArticle = await _dbContext.Pictures.FirstOrDefaultAsync(z => z.Id == id);
                return dbArticle;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }

        public async Task<Pictures> GetLastAsunc()
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} ");
                var dbArticle = await _dbContext.Pictures.LastOrDefaultAsync();
                return dbArticle;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return null;
            }
        }
        public async Task<IResult> AddAsync(Pictures picture)
        {
            try
            {
                //if (picture.Id == null)
                //{
                //    Guid guid = Guid.NewGuid();
                //    picture.Id=guid.ToString();
                //}
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} " +
                                    $"Parametrs:articleId={picture.Id}");
                

                //заменить на процедуру добавления в sql 
                _dbContext.Pictures.Add(picture);
                await _dbContext.SaveChangesAsync();
                //List<AuthorArticle> authors = new List<AuthorArticle>();
                //если запись параллельна что тогда 

                //string name = _dbContext.Pictures.MaxAsync(x => x.Id).Result;
                // не нужно 
                return await Task.FromResult(Result.Success());

            }
            catch (Exception ex)
            {
                _logger.Error($"Error:{ex.ToString()}");
                return await Task.FromResult(Result.Fail());
            }
        }

        public async Task<IResult> DeleteAsync(Pictures picture)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:picture={picture.Id}");
                var currentPicture = _dbContext.Pictures.FirstOrDefaultAsync(z => z.Id == picture.Id).Result;
                if (currentPicture == null)
                    return await Task.FromResult(Result.Fail("Not found"));
                _dbContext.Pictures.Remove(currentPicture);
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
        }
        public async Task<IResult> UpdateAsync(Pictures picture)
        {
            try
            {
                _logger.Information($"Method:{MethodBase.GetCurrentMethod().DeclaringType.FullName} Parametrs:articleId={picture.Id}");
                //throw new NotImplementedException();p
                var currentPicture = _dbContext.Pictures.FirstOrDefaultAsync(z => z.Id == picture.Id).Result;
                if (currentPicture == null)
                {
                    return await Task.FromResult(Result.Fail());
                }
                currentPicture.Id = picture.Id;
                currentPicture.ImagePath = picture.ImagePath;
                _dbContext.Pictures.Update(currentPicture);
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
    }
}
