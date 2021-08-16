using System;
using Art.WebPresentation.Data;
using Art.WebPresentation.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Art.WebPresentation.Areas.Identity.IdentityHostingStartup))]
namespace Art.WebPresentation.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<ArtWebPresentationContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("ArtWebPresentationContextConnection")));

            //    services.AddDefaultIdentity<UsersViewModel>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<ArtWebPresentationContext>();
            //});
        }
    }
}