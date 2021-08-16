using Art.DataAccess.Article.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Art.DataAccess.User.Models
{
    public partial class Users : IdentityUser
    {
        public Users()
        {
            //AspNetUserClaims = new HashSet<AspNetUserClaims>();
            //AspNetUserLogins = new HashSet<AspNetUserLogins>();
            //AspNetUserRoles = new HashSet<AspNetUserRoles>();
            //AspNetUserTokens = new HashSet<AspNetUserTokens>();
            Authors = new HashSet<Authors>();
            UserArticle = new HashSet<UserArticle>();
        }

        public override string Id { get; set; }
        public override string UserName { get; set; }
        public override string NormalizedUserName { get; set; }
        public override string Email { get; set; }
        public override string NormalizedEmail { get; set; }
        public override bool EmailConfirmed { get; set; }
        public override string PasswordHash { get; set; }
        public override string SecurityStamp { get; set; }
        public override string ConcurrencyStamp { get; set; }
        public override string PhoneNumber { get; set; }
        public override bool PhoneNumberConfirmed { get; set; }
        public override bool TwoFactorEnabled { get; set; }
        public override DateTimeOffset? LockoutEnd { get; set; }
        public override bool LockoutEnabled { get; set; }
        public override int AccessFailedCount { get; set; }

        /// <summary>
        /// понравившиеся статьи 
        /// </summary>
        //public virtual ICollection<Articles> UserLikeArticles { get;set;}
        public virtual ICollection<UserArticle> UserArticle { get; set; }
        //public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }
        //public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }
        //public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }
        //public virtual ICollection<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual ICollection<Authors> Authors { get; set; }

    }
}
