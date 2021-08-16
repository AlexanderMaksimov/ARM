using Art.WebPresentation.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Art.WebPresentation.Models
{
        public partial class UsersViewModel : IdentityUser
        {
            public UsersViewModel()
            {
                Authors = new HashSet<AuthorsViewModel>();
                UserArticle = new HashSet<UserArticleViewModel>();
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
            public virtual ICollection<UserArticleViewModel> UserArticle { get; set; }
            public virtual ICollection<AuthorsViewModel> Authors { get; set; }

        }
    

}
