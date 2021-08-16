using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Art.WebPresentation.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Art.Engine.User.Interface;
using Art.Engine.Article.Interface;
using Art.Engine.User.Implementation;
using Art.Engine.Article.Implementation;
using Art.WebPresentation.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Art.WebPresentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserEngine, UserEngine>();
            services.AddTransient<IArtikleEngine, ArtikleEngine>();
            services.AddTransient<IFindArtikleEngine, FindArtikleEngine>();
            services.AddTransient<ITopicEngine, TopicEngine>();
            services.AddTransient<IPictureEngine, PictureEngine>();
            services.AddTransient<IUserEngine, UserEngine>();           
            services.AddSingleton((Serilog.ILogger)Log.Logger);
            services.AddAutoMapper(typeof(MappingProfile));//простая версия маппинга настройки в MappingProfile
                                                           //        services.AddAuthentication(IdentityConstants.ApplicationScheme)
                                                           //.AddCookie(IdentityConstants.ApplicationScheme);
                                                           //services.AddAuthentication(IdentityConstants.ApplicationScheme)
                                                           //.AddCookie(IdentityConstants.ApplicationScheme);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme);
            //services().AddCookies("Identity.Application", ...) ?
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                    name: "Articles2",
                    pattern: "{controller=Article}/{action=Index}");
                endpoints.MapRazorPages();

                endpoints.MapAreaControllerRoute(
                    areaName: "Article",
                    name: "Articles",
                    pattern: "{controller=/Account/Article}/{action=Index}");
                endpoints.MapRazorPages();
            });
        }
    }
}
