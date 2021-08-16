using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
//using System.Linq;
using System.Linq;
using Art.Engine.User.Interface;
using Art.Engine.User.Models;
using Art.Engine.Article.Interface;
using Art.DataAccess.User.Implementation;
using Art.Engine.Infrastructure;
using Art.DataAccess.User.Interface;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Art.Engine.User.Implementation
{
    public class UserEngine : IUserEngine
    {
        protected IServiceProvider Provider { get; set; }
        public SignInManager SignInManager { get;  }
        public RolesManager RolesManager { get; }
        public UsersManager UsersManager { get; }
        protected IUserDataAccess UserDataAccess { get; set; }
        public IEmailSender EmailSender { get; set; }
        public UserEngine()
        {
            Provider = InitServiceProviderEngine.GetInstance().ServiceProvider;
            UserDataAccess = Provider.GetService<IUserDataAccess>();
            RolesManager= UserDataAccess.RolesManager;
            UsersManager = UserDataAccess.UsersManager;
            SignInManager = UserDataAccess.SignInManager;
            EmailSender = UserDataAccess.EmailSender;
        }
        public async Task<List<UsersEngine>> GetAllAsync(int count)
        {
            try
            {
                // var dbUser = await _dbContext.UsersEngine.Take(count).ToListAsync();
                //return dbUser;
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<UsersEngine> GetAsync(string userName="", string email = "")
        {
            try
            {
              //  var dbUser= await _dbContext.UsersEngine.FirstOrDefaultAsync(z=>z.UserName==userName||z.Email==email);
              //      return dbUser;
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IResultEngine> Add(UsersEngine user)
        {
            try
            {
                if (user == null)
                    return await Task.FromResult(ResultEngine.Fail("topic null"));
                throw new NotImplementedException();
                //await _dbContext.AddAsync(user);
                //int result = await _dbContext.SaveChangesAsync(); ;
                //if (result >= 0)
                //    return await Task.FromResult(ResultEngine.Success());
                //else
                //    return await Task.FromResult(ResultEngine.Fail("Not add"));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ResultEngine.Fail("Not add"));
            }
            //throw new NotImplementedException();
        }

        public async Task<IResultEngine> AddOrUpdate(UsersEngine user)
        {
            try
            {
                throw new NotImplementedException();
                //if (user == null)
                //    return await Task.FromResult(ResultEngine.Fail());
                //var dbUser = _dbContext.UsersEngine.FirstOrDefaultAsync(z => z.UserName == user.UserName).ResultEngine;
                //if (dbUser != null)
                //    return await Add(user);
                ////изменяются только UserName
                //dbUser.UserName = user.UserName;
                //int result = await _dbContext.SaveChangesAsync();
                //if (result >= 0)
                //    return await Task.FromResult(ResultEngine.Success());
                //else
                //    return await Task.FromResult(ResultEngine.Success("Not update"));

            }
            catch (Exception ex)
            {
                 return await Task.FromResult(ResultEngine.Fail("Not update"));
            }
            // throw new NotImplementedException();
        }

        public async Task<IResultEngine> Delete(UsersEngine user)
        {
            try
            {
                throw new NotImplementedException();
                //if (user == null)
                //    return await Task.FromResult(ResultEngine.Fail());
                //var dbUser = _dbContext.UsersEngine.FirstOrDefaultAsync(z => z.UserName == user.UserName).ResultEngine;
                //if (dbUser != null)
                //    return await Add(user);

                //_dbContext.Remove(dbUser);
                //int result = await _dbContext.SaveChangesAsync();
                //if (result >= 0)
                //    return await Task.FromResult(ResultEngine.Success());
                //else
                //    return await Task.FromResult(ResultEngine.Success("Not Delete"));

            }
            catch (Exception ex)
            {
                return await Task.FromResult(ResultEngine.Fail("Not Delete"));
            }
        }

    }
}
