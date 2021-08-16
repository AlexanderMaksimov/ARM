using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;
using Art.DataAccess.User.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Serilog;
using Microsoft.Extensions.Logging;
using Serilog.AspNetCore;
using Art.DataAccess.User.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Art.DataAccess.Article.Implementation
{
    public class InitServiceProviderDA
    {
        public IServiceProvider ServiceProvider { get; private set; }
        protected IConfiguration Configuration { get; }
        protected static InitServiceProviderDA instance;

        //Singltone для многопоточной реализации
        private static readonly Lazy<InitServiceProviderDA> lazy =
         new Lazy<InitServiceProviderDA>(() => new InitServiceProviderDA());

        public static InitServiceProviderDA GetInstance() => lazy.Value;

        //Singltone стандартный 
        //public static ServiceProviderDataAccess GetServiceProviderDataAccess()
        //{
        //    if (instance == null)
        //    {
        //        instance = new ServiceProviderDataAccess();
        //    }
        //    return instance;
        //}
        //Singltone стандартный  версия 2
        //public static ServiceProviderDataAccess Current => instance ?? (instance = new ServiceProviderDataAccess());


        private InitServiceProviderDA()
        {

            string currentDir = Environment.CurrentDirectory;
            string directorArt = currentDir.Substring(0, currentDir.IndexOf("Art") - 1);
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(directorArt, @"Art\Art.DataAccess\appsettings.json")));

            var builder = new ConfigurationBuilder()
                 .AddJsonFile(directory.ToString(), optional: false, reloadOnChange: true)
                 .AddEnvironmentVariables();
            //        var builder = new ConfigurationBuilder()
            //.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.AddEnvironmentVariables();

            Configuration = builder.Build();

            RegisterServices();
            //var service = _serviceProvider.GetService<IDemoService>();
            //service.DoSomething();

            // DisposeServices();
        }

        protected void RegisterServices()
        {
            //Serilog
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            var serilogLogger= new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            var loggerFactory = (ILoggerFactory)new LoggerFactory();
            loggerFactory.AddSerilog(serilogLogger);
            //ConfigureServices
            //setup our DI
            string connection = Configuration.GetConnectionString("ArticleConnection");
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // serviceCollection.AddTransient<IArtikleDataAccess, ArtikleDataAccess>();
            // serviceCollection.AddTransient<IFindArtikleDataAccess, FindArtikleDataAccess>();
            serviceCollection.AddDbContext<ArticleDbContext>(options => options.UseSqlServer(connection));
            serviceCollection.AddScoped<SignInManager<Users>, SignInManager>();
            serviceCollection.AddScoped<UserManager<Users>, UsersManager>();
            serviceCollection.AddIdentity<Users, IdentityRole>()
                .AddDefaultUI()                    
                    .AddUserManager<UsersManager>()
                    .AddEntityFrameworkStores<ArticleDbContext>()
                    .AddDefaultTokenProviders()
                    .AddSignInManager<SignInManager>();

            serviceCollection.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
              
            //serviceCollection.AddAuthentication(IdentityConstants.ApplicationScheme)
            //    .AddCookie(IdentityConstants.ApplicationScheme);
            //serviceCollection.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //}).AddCookie();
            //    services.AddIdentity<ApplicationUser, IdentityRole>()
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders()
            //.AddUserManager<AuditableUserManager<ApplicationUser>>();

            //    services.AddScoped<SignInManager<ApplicationUser>, AuditableSignInManager<ApplicationUser>>();

            //serviceCollection.AddIdentity<Users, UserRole>()
            //        .AddEntityFrameworkStores<ArticleDbContext>()
            //        .AddDefaultTokenProviders();
            serviceCollection.AddSingleton((Serilog.ILogger)Log.Logger);
            serviceCollection.AddLogging();
            //serviceCollection.AddTransient<UsersManager>();
            
           // serviceCollection.AddTransient<SignInManager>();
           // serviceCollection.AddTransient<RolesManager>();
            // serviceCollection.AddSingleton<ILoggerFactory>(loggerFactory.CreateLogger());

            // .AddDefaultUI();
            ServiceProvider = serviceCollection.BuildServiceProvider();
            var t = ServiceProvider.GetService<UsersManager>();
            var tf = ServiceProvider.GetService<SignInManager>();
            //.AddSingleton<IBarService, BarService>()


            //configure console logging 
            //Microsoft.Extensions.Logging;
            //var loggerFactory = LoggerFactory.Create(loggingBuilder =>
            //{
            //    loggingBuilder.AddConfiguration(Configuration.GetSection("Logging"));

            //    loggingBuilder.AddConsole();
            //    loggingBuilder.AddDebug();
            //});
            //ILogger logger = loggerFactory.CreateLogger<InitServiceProviderDA>();

            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();
            // logger.LogDebug("Starting application");

            //do the actual work here
            //var bar = serviceProvider.GetService<IBarService>();
            // bar.DoSomeRealWork();

        }

        //protected void DisposeServices()
        //{
        //    if (ServiceProviderDataAccess == null)
        //    {
        //        return;
        //    }
        //    if (ServiceProviderDataAccess is IDisposable)
        //    {
        //        ((IDisposable)ServiceProviderDataAccess).Dispose();
        //    }
        //}

        //public void Dispose()
        //{
        //    DisposeServices();
        //}
    }
}
