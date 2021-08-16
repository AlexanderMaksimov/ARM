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
using Art.Engine.Article.Interface;
using Art.DataAccess.Article.Implementation;
using Art.DataAccess.Article.Interface;
using AutoMapper;
using Art.Engine.User.Interface;
using Art.Engine.User.Implementation;
using Art.DataAccess.User.Interface;
using Art.DataAccess.User.Implementation;

namespace Art.Engine.Infrastructure
{
    public class InitServiceProviderEngine
    {
        public IServiceProvider ServiceProvider { get; private set; }
        protected IConfiguration Configuration { get; }
        protected static InitServiceProviderEngine instance;

        //Singltone для многопоточной реализации
        private static readonly Lazy<InitServiceProviderEngine> lazy =
         new Lazy<InitServiceProviderEngine>(() => new InitServiceProviderEngine());

        public static InitServiceProviderEngine GetInstance() => lazy.Value;

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


        private InitServiceProviderEngine()
        {
            string currentDir = Environment.CurrentDirectory;
            string directorArt = currentDir.Substring(0, currentDir.IndexOf("Art") - 1);
            DirectoryInfo directory = new DirectoryInfo(
                Path.GetFullPath(Path.Combine(directorArt, @"Art\Art.Engine\appsettings.json")));

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
            var serilogLogger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            var loggerFactory = (ILoggerFactory)new LoggerFactory();
            loggerFactory.AddSerilog(serilogLogger);
            //ConfigureServices
            // версия для Mapper c настройками из mappingConfig
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
                // I want the profile to set the configuration, if I set this here the test passes
                cfg.AllowNullCollections = true;
            });
            IMapper mapper = mappingConfig.CreateMapper();
            //  serviceCollection.AddSingleton(mapper);

            //setup our DI
            string connection = Configuration.GetConnectionString("ArticleConnection");
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddAutoMapper(typeof(MappingProfile));//простая версия маппинга настройки в MappingProfile
            serviceCollection.AddTransient<IArtikleDataAccess, ArtikleDataAccess>();
            serviceCollection.AddTransient<IPictureDataAccess, PictureDataAccess>();
            serviceCollection.AddTransient<ITopicDataAccess, TopicDataAccess>();
            serviceCollection.AddTransient<IFindArtikleDataAccess, FindArtikleDataAccess>();
            serviceCollection.AddTransient<IUserDataAccess, UserDataAccess>();
            serviceCollection.AddSingleton((Serilog.ILogger)Log.Logger);
            // serviceCollection.AddSingleton<ILoggerFactory>(loggerFactory.CreateLogger());

            ServiceProvider = serviceCollection.BuildServiceProvider();

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
