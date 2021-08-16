using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
//using System.Linq;
using Art.DataAccess.User.Models;
using Art.DataAccess.User.Interface;
using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Implementation;
using System.Linq;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;

namespace Art.DataAccess.User.Implementation
{
    public class UserDataAccess : IUserDataAccess
    {
        protected IServiceProvider _provider { get; set; }
        public SignInManager SignInManager { get; set; }
        public RolesManager RolesManager { get ; set ; }
        public UsersManager UsersManager { get ; set ; }
        public IEmailSender EmailSender { get; set; }
        protected readonly UserDbContext _dbContext;

        public UserDataAccess()
        {
            _provider = InitServiceProviderDA.GetInstance().ServiceProvider;
            _dbContext = _provider.GetService<UserDbContext>();
            UsersManager = _provider.GetService<UsersManager>();
            RolesManager= _provider.GetService<RolesManager>();
             SignInManager = _provider.GetService<SignInManager>();
            EmailSender= _provider.GetService<IEmailSender>();
        }
        public async Task<List<Users>> GetAllAsync(int count)
        {
            try
            {
                var dbUser = await _dbContext.Users.Take(count).ToListAsync();
                return dbUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Users> GetAsync(string userName="", string email = "")
        {
            try
            {
                var dbUser =await UsersManager.FindByNameAsync(userName);
                //var dbUser= await _dbContext.Users.FirstOrDefaultAsync(z=>z.UserName==userName||z.Email==email);
                 return dbUser;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IResult> Add(Users user)
        {
            try
            {
                if (user == null)
                    return await Task.FromResult(Result.Fail("topic null"));
                await _dbContext.AddAsync(user);
                int result = await _dbContext.SaveChangesAsync(); ;
                if (result >= 0)
                    return await Task.FromResult(Result.Success());
                else
                    return await Task.FromResult(Result.Fail("Not add"));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Result.Fail("Not add"));
            }
            //throw new NotImplementedException();
        }

        public async Task<IResult> AddOrUpdate(Users user)
        {
            try
            {
                if (user == null)
                    return await Task.FromResult(Result.Fail());
                var dbUser = _dbContext.Users.FirstOrDefaultAsync(z => z.UserName == user.UserName).Result;
                if (dbUser != null)
                    return await Add(user);
                //изменяются только UserName
                dbUser.UserName = user.UserName;
                int result = await _dbContext.SaveChangesAsync();
                if (result >= 0)
                    return await Task.FromResult(Result.Success());
                else
                    return await Task.FromResult(Result.Success("Not update"));

            }
            catch (Exception ex)
            {
                 return await Task.FromResult(Result.Fail("Not update"));
            }
            // throw new NotImplementedException();
        }

        public async Task<IResult> Delete(Users user)
        {
            try
            {
                if (user == null)
                    return await Task.FromResult(Result.Fail());
                var dbUser = _dbContext.Users.FirstOrDefaultAsync(z => z.UserName == user.UserName).Result;
                if (dbUser != null)
                    return await Add(user);

                _dbContext.Remove(dbUser);
                int result = await _dbContext.SaveChangesAsync();
                if (result >= 0)
                    return await Task.FromResult(Result.Success());
                else
                    return await Task.FromResult(Result.Success("Not Delete"));

            }
            catch (Exception ex)
            {
                return await Task.FromResult(Result.Fail("Not Delete"));
            }
        }

    }
}
