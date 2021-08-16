using Art.DataAccess.User.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Art.DataAccess.User.Implementation
{
    public class SignInManager : SignInManager<Users>
    {
        public SignInManager(UserManager<Users> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<Users> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<Users>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<Users> confirmation) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }
    }
}
