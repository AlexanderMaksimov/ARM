﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art.WebPresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Art.WebPresentation.Data
{
    public class ArtWebPresentationContext : IdentityDbContext<UsersViewModel>
    {
        public ArtWebPresentationContext(DbContextOptions<ArtWebPresentationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
