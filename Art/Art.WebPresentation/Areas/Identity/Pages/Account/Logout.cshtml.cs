using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Art.WebPresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Art.Engine.User.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Art.WebPresentation.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private IUserEngine _userEngine { get; set; }
        private ILogger<LoginModel> _logger { get; set; }
        private IServiceProvider _provider { get; set; }
        public LogoutModel(IServiceProvider provider)
        {
            _provider = provider;
            _userEngine = _provider.GetService<IUserEngine>();
            _logger = provider.GetService<ILogger<LoginModel>>();
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _userEngine.SignInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
