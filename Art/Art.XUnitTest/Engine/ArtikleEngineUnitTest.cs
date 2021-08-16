using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;
using Art.DataAccess.User.Models;
using Art.Engine.Article.Implementation;
using Art.Engine.Article.Interface;
using Art.Engine.Infrastructure;
using Art.Engine.Article.Models;
using Art.Engine.User.Models;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Serilog;
using System;
using System.Collections.Generic;
using Xunit;

using System.Threading.Tasks;
using static Art.DataAccess.Article.Models.Articles;

namespace Art.XUnitTest.Engine
{
    public class ArtikleEngineFixture
    {
        public ArtikleEngineFixture()
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();

            Provider = new ServiceCollection()
            .AddSingleton((Serilog.ILogger)Log.Logger)
            .AddAutoMapper(typeof(MappingProfile))
            //.AddTransient<IArtikleEngine, ArtikleEngine>()
            //.AddSingleton<IBarService, BarService>()
            .BuildServiceProvider();
        }
        public IServiceProvider Provider { get; private set; }

    }
    public class ArtikleEngineUnitTest : IClassFixture<ArtikleEngineFixture>
    {
        // public IArtikleDataAccess artikleDataAccess;
        protected IServiceProvider Provider { get; private set; }
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        public ArtikleEngineUnitTest()
        {
            Provider = new ArtikleEngineFixture().Provider;
            Logger = Provider.GetService<ILogger>();
            Mapper = Provider.GetService<IMapper>();
        }
        [Fact]
        public void GetDate()
        {
            // Arrange
            int countArticle = 100;
            List<Articles> articles = new List<Articles>();
            for (int i = 0; i < countArticle; i++)
            { articles.Add(new Articles()); }
            var mock = new Mock<IArtikleDataAccess>();
            mock.Setup(repo => repo.GetAllAsync(0,100)).ReturnsAsync(articles);
            var artikleEngine = new ArtikleEngine(Logger, Mapper, mock.Object);

            // Act
            var result = artikleEngine.GetAllAsync(0, 100).Result;

            // Assert
            Assert.NotEmpty(result);
        }
        [Fact]
        public void GetDateId()
        {
            // Arrange
            Articles resultArticle = new Articles();
            var mock = new Mock<IArtikleDataAccess>();
            mock.Setup(repo => repo.GetAsync(1)).ReturnsAsync(resultArticle);
            var artikleEngine = new ArtikleEngine(Logger, Mapper, mock.Object);

            // Act
            var result = artikleEngine.GetAsync(1).Result;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetLast()
        {
            // Arrange
            Articles resultArticle = new Articles() { Name="Devid"};
            var mock = new Mock<IArtikleDataAccess>();
            mock.Setup(repo => repo.GetLastAsunc()).ReturnsAsync(resultArticle);
            var artikleEngine = new ArtikleEngine(Logger, Mapper, mock.Object);

            // Act
            var result = artikleEngine.GetLastAsunc().Result;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddDate()
        {
            // Arrange
            Articles article = new Articles()
            {
                Context = "Тестовая статья ",
                Description = "Тест краткое описание",
                Name = "Тест",
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now,
                Rating = 0,
                StatusVisibleUser = (int)StatusVisible.VisibleAdmin,
                StatusPublication = (int)StatusArticle.LineForChecked,
                JointAuthors = "Devid",
                Author = new Authors() { AuthorId = 1 },
                TopicArticle= new List<TopicArticle>() { new TopicArticle() { TopicId=1} },
                UserArticle =new List<UserArticle>() { new UserArticle() { UserId="1234"} }

            };
            //Users user = new Users()
            //{
            //    Id = "1234",
            //    UserName = "admin"
            //};
            //int topicId = 1019;
            //Task.FromResult(Result.Success())
            var mock = new Mock<IArtikleDataAccess>();
            IResult returnAdd = Result.Success();
            // mock.Setup(repo => repo.AddAsync(article)).Returns(Task.FromResult(returnAdd));
            mock.Setup(repo => repo.AddAsync(article)).ReturnsAsync(returnAdd);
           // mock.Setup(repo => repo.AddAsync(new Articles())).ReturnsAsync(Result.Success());
           // mock.Setup(repo => repo.AddAsync(article)).Returns(Task.FromResult(returnAdd));
            var dbartq = Mapper.Map<ArticleModelEngine>(article);
            var dbartre = Mapper.Map<Articles>(dbartq);
            var asres = mock.Object.AddAsync(article).Result;
            Console.WriteLine(asres);
            var moqO = mock.Object;
            var artikleEngine = new ArtikleEngine(Logger, Mapper, moqO);
            // Act
            var dbart = Mapper.Map<ArticleModelEngine>(article);
            // var result = artikleEngine.AddAsync(dbart).Result;
            var result = artikleEngine.AddAsync(dbart).Result;
            // Assert
            Assert.True(result.Succeeded);
        }
        [Fact]
        public void Update()
        {
            Articles article = new Articles()
            {
                ArticleId=1,
                Context = "Тестовая статья ",
                Description = "Тест краткое описание",
                Name = "Тест",
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now,
                Rating = 0,
                StatusVisibleUser = (int)StatusVisible.VisibleAdmin,
                StatusPublication = (int)StatusArticle.LineForChecked,
                JointAuthors = "Devid",
                Author = new Authors() { AuthorId = 1 },
                TopicArticle = new List<TopicArticle>() { new TopicArticle() { TopicId = 1 } }

            };
            var mock = new Mock<IArtikleDataAccess>();
            Result returnAdd = Result.Success();
            mock.Setup(repo => repo.UpdateAsync(article)).ReturnsAsync(returnAdd);
            var artikleEngine = new ArtikleEngine(Logger, Mapper, mock.Object);
            // Act
            var dbart = Mapper.Map<ArticleModelEngine>(article);
            var result = artikleEngine.UpdateAsync(dbart);

            // Assert
            Assert.True(result.Result.Succeeded);
        }
        [Fact]
        public void Delete()
        {
            // Arrange
            Articles article = new Articles()
            {
                ArticleId = 1,
                Context = "Тестовая статья удаление ",
                Description = "Тест краткая описание удаление",
                Name = "Тест",
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now,
                Rating = 0,
                StatusVisibleUser = (int)StatusVisible.VisibleAdmin,
                StatusPublication = (int)StatusArticle.LineForChecked,
                JointAuthors = "Devid",
                Author = new Authors() { AuthorId = 1 },
                TopicArticle = new List<TopicArticle>() { new TopicArticle() { TopicId = 1 } }

            };
            var mock = new Mock<IArtikleDataAccess>();
            Result returnAdd = Result.Success();
            mock.Setup(repo => repo.DeleteAsync(article)).ReturnsAsync(returnAdd);
            var artikleEngine = new ArtikleEngine(Logger, Mapper, mock.Object);
            //Act
            var dbart = Mapper.Map<ArticleModelEngine>(article);
            var result = artikleEngine.DeleteAsync(dbart);
            // Assert
            Assert.True(result.Result.Succeeded);
        }
    }
}
