using Art.DataAccess.User.Implementation;
using Art.Engine.Article.Interface;
using Art.Engine.User.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Art.Engine.User.Interface
{
    public interface IUserEngine
    {
        SignInManager SignInManager { get; }
        RolesManager RolesManager { get; }
        UsersManager UsersManager { get; }
        IEmailSender EmailSender { get; set; }
        Task<UsersEngine> GetAsync(string userName, string email);
        Task<List<UsersEngine>> GetAllAsync(int count);
        Task<IResultEngine> Add(UsersEngine user);
        Task<IResultEngine> AddOrUpdate(UsersEngine user);
        Task<IResultEngine> Delete(UsersEngine user);

    }
}
