using Art.DataAccess.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Art.DataAccess.User.Implementation
{
    public class RolesManager : RoleManager<IdentityRole>
    {
        public RolesManager(IRoleStore<IdentityRole> store, IEnumerable<IRoleValidator<IdentityRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<IdentityRole>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
    //public class RolesManager : RoleManager<UserRole>
    //{
    //    public RolesManager(IRoleStore<UserRole> store, IEnumerable<IRoleValidator<UserRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<UserRole>> logger) 
    //        : base(store, roleValidators, keyNormalizer, errors, logger)
    //    {
    //    }
    //}
}
