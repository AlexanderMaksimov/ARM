using Art.DataAccess.Article.Implementation;
using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;
using Art.DataAccess.User.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Xunit;
using static Art.DataAccess.Article.Models.Articles;

namespace Art.XUnitTest.DataAccess
{
    public class ArtikleDataAccessFixture
    {
        public ArtikleDataAccessFixture()
        {
            Provider = new ServiceCollection()
            .AddLogging()
            .AddTransient<IArtikleDataAccess, ArtikleDataAccess>()
            //.AddSingleton<IBarService, BarService>()
            .BuildServiceProvider();
        }
        public IServiceProvider Provider { get; private set; }

    }
    public class ArtikleDataAccessUnitTest : IClassFixture<ArtikleDataAccessFixture>
    {
        // public IArtikleDataAccess artikleDataAccess;
        protected IServiceProvider Provider { get; private set; }
        protected IArtikleDataAccess ArtikleDataAccess { get; set; }
        public ArtikleDataAccessUnitTest()
        {
            Provider = new ArtikleDataAccessFixture().Provider;
            ArtikleDataAccess = Provider.GetService<IArtikleDataAccess>();
        }
        [Fact]
        public void GetDate()
        {
            // Arrange
            // var artikleDataAccess = Provider.GetService<IArtikleDataAccess>();
            int countArticle = 100;
            // Act
            var result = ArtikleDataAccess.GetAllAsync(0,100).Result;

            // Assert
            Assert.NotEmpty(result);
        }
        [Fact]
        public void GetDateId()
        {
            // Arrange
            // var artikleDataAccess = Provider.GetService<IArtikleDataAccess>();

            // Act
            var result = ArtikleDataAccess.GetAsync(2).Result;

            // Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void AddDate()
        {
            // Arrange
            // var artikleDataAccess = Provider.GetService<IArtikleDataAccess>();
            Users user = new Users()
            {
                Id = "1234",
                UserName = "admin"
            };
            Articles article = new Articles
            {
                Context = "Тестовая статья ",
                Description = "Тест краткое описание",
                Name = "Тест",
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now,
                Rating = 0,
                StatusVisibleUser = (int)StatusVisible.VisibleAdmin,
                StatusPublication = (int)StatusArticle.LineForChecked,
                AuthorId = 1,
                TopicArticle = new List<TopicArticle>()
                {new TopicArticle(){TopicId=1}},
                JointAuthors = "Piter",
                UserArticle = new List<UserArticle>() { new UserArticle() { UserId = "1234" } }



            };
            //int topicId = 1;
            // Act
            var result = ArtikleDataAccess.AddAsync(article);

            // Assert
            Assert.True(result.Result.Succeeded);
        }
        [Fact]
        public void Update()
        {
            //Arrange
            Articles article = new Articles
            {
                ArticleId = 1,
                Context = " статья oбновлена",
                Description = " краткое описание oбновлена",
                Name = "oбновлена",
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now,
                Rating = 0,
                StatusVisibleUser = (int)StatusVisible.VisibleAdmin,
                StatusPublication = (int)StatusArticle.LineForChecked
            };
            //Act
            var result = ArtikleDataAccess.AddAsync(article);
            // Assert
            Assert.True(result.Result.Succeeded);
        }
        [Fact]
        public void Delete()
        {
            // Arrange
            Articles article = new Articles
            {
                Context = " delete",
                Description = "delete",
                Name = "delete",
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now,
                Rating = 0,
                StatusVisibleUser = (int)StatusVisible.VisibleAdmin,
                StatusPublication = (int)StatusArticle.LineForChecked,
                AuthorId=1,
                TopicArticle=new List<TopicArticle>() { new TopicArticle() { TopicId=1} }
            };
            var t= ArtikleDataAccess.AddAsync(article).Result;
            var lastArticle = ArtikleDataAccess.GetLastAsunc().Result;
            //Act
            var result = ArtikleDataAccess.DeleteAsync(lastArticle);
            // Assert
            Assert.True(result.Result.Succeeded);

        }
        [Fact]
        public void GetLastAsunc()
        {
            // Arrange

            // Act
            var result = ArtikleDataAccess.GetLastAsunc().Result;

            // Assert
            Assert.NotNull(result);
        }
    }
}
