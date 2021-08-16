using Art.DataAccess.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Art.DataAccess.User.Implementation
{
    public class UsersManager : UserManager<Users>
    {
        public UsersManager(IUserStore<Users> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<Users> passwordHasher, IEnumerable<IUserValidator<Users>> userValidators, IEnumerable<IPasswordValidator<Users>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<Users>> logger) 
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}
