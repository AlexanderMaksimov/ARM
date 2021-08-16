using Art.DataAccess.Article.Interface;
using Art.DataAccess.User.Implementation;
using Art.DataAccess.User.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Art.DataAccess.User.Interface
{
    public interface IUserDataAccess
    {
        SignInManager SignInManager { get; set; }
        RolesManager RolesManager { get; set; }
        UsersManager UsersManager { get; set; }
        IEmailSender EmailSender { get; set; }
        Task<Users> GetAsync(string userName, string email);
        Task<List<Users>> GetAllAsync(int count);
        Task<IResult> Add(Users user);
        Task<IResult> AddOrUpdate(Users user);
        Task<IResult> Delete(Users user);

    }
}
