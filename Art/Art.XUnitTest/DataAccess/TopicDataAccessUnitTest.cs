using Art.DataAccess.Article.Implementation;
using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Art.XUnitTest.DataAccess
{
    public class TopicDataAccessFixture : IDisposable
    {
        public TopicDataAccessFixture()
        {
            Provider = new ServiceCollection()
            .AddLogging()
            .AddTransient<ITopicDataAccess, TopicDataAccess>()
            //.AddSingleton<IBarService, BarService>()
            .BuildServiceProvider();
        }
        public IServiceProvider Provider { get; private set; }
        public void Dispose()
        {
            // ... clean up test data from the database ...
        }

    }
    public class TopicDataAccessUnitTest : IClassFixture<TopicDataAccessFixture>
    {
        protected IServiceProvider Provider { get; private set; }
        protected ITopicDataAccess TopicDataAccess { get; set; }

        public TopicDataAccessUnitTest()
        {
            Provider = new TopicDataAccessFixture().Provider;
            TopicDataAccess = Provider.GetService<ITopicDataAccess>();
        }

        [Fact]
        public void GetAll()
        {
            // Arrange
            int count = 100;
            // Act
            var result = TopicDataAccess.GetAllAsync();

            // Assert
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void GetId()
        {
            // Arrange
            // var artikleDataAccess = Provider.GetService<IArtikleDataAccess>();
            int id = 1;
            // Act
            var result = TopicDataAccess.GetAsync(id);

            // Assert
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void GetLast()
        {
            // Arrange
            // var artikleDataAccess = Provider.GetService<IArtikleDataAccess>();
            int id = 1;
            // Act
            var result = TopicDataAccess.GetFirstAsunc();

            // Assert
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void  Add()
        {
            // Arrange
            Topics topic = new Topics()
            {
                Name = "Тестовая тема",
                Description = "Тестовая тема описание"
            };
            // Act
            var result = TopicDataAccess.AddAsync(topic).Result;

            // Assert
            Assert.True(result.Succeeded);
        }

        [Fact]
        public void Update()
        {
            // Arrange
            // var artikleDataAccess = Provider.GetService<IArtikleDataAccess>();
            //add
            var lastTopic = TopicDataAccess.GetFirstAsunc().Result;
            Topics topic = new Topics()
            {
                TopicId= lastTopic.TopicId,
                Name = "Тестовая тема Обновление",
                Description = "Тестовая тема описание Обновление"
            };
            // Act
            var result = TopicDataAccess.UpdateAsync(topic).Result;

            // Assert
            Assert.True(result.Succeeded);
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            // var artikleDataAccess = Provider.GetService<IArtikleDataAccess>();
            //add
            Topics topic = new Topics()
            {
                Name = "Тестовая тема",
                Description = "Тестовая тема описание"
            };
            var resultAdd = TopicDataAccess.AddAsync(topic).Result;
            var lastTopic = TopicDataAccess.GetFirstAsunc().Result;

            // Act
            var result = TopicDataAccess.DeleteAsync(lastTopic).Result;

            // Assert
            Assert.True(result.Succeeded);
        }
        [Fact]
        public void GetLastAsunc() 
        {
            // Arrange

            // Act
            var result = TopicDataAccess.GetFirstAsunc().Result;

            // Assert
            Assert.NotNull(result);
        }

    }
}
