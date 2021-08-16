using Art.DataAccess.Article.Implementation;
using Art.DataAccess.Article.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Art.XUnitTest.DataAccess
{
    public class FindArtikleDataAccessFixture : IDisposable
    {
        public FindArtikleDataAccessFixture()
        {
            Provider = new ServiceCollection()
            .AddLogging()
            .AddTransient<IFindArtikleDataAccess, FindArtikleDataAccess>()
            //.AddSingleton<IBarService, BarService>()
            .BuildServiceProvider();            
        }
        public IServiceProvider Provider { get; private set; }
        public void Dispose()
        {
            // ... clean up test data from the database ...
        }

    }
    public class FindArtikleDataAccessUnitTest : IClassFixture<ArtikleDataAccessFixture>
    {
        protected IServiceProvider Provider { get; private set; }
        protected IFindArtikleDataAccess FindArtikleDataAccess { get;  set; }

        public FindArtikleDataAccessUnitTest()
        {
            Provider = new FindArtikleDataAccessFixture().Provider;
            FindArtikleDataAccess = Provider.GetService<IFindArtikleDataAccess>();
        }

        [Fact]
        public void Find()
        {
            // Arrange
            // var artikleDataAccess = Provider.GetService<IArtikleDataAccess>();
            string findText = "тест";
            // Act
            var result = FindArtikleDataAccess.FindAsync(findText);

            // Assert
            Assert.NotNull(result.Result);
        }
        [Fact]
        public void FindByName()
        {
            // Arrange
            string findText = "Тест 1";
            // Act
            var result = FindArtikleDataAccess.FindByNameAsync(findText);

            // Assert
            Assert.NotNull(result.Result);
        }
        [Fact]
        public void FindByDescription()
        {
            // Arrange
            string findText = "описание 1";
            // Act
            var result = FindArtikleDataAccess.FindByNameAsync(findText);

            // Assert
            Assert.NotNull(result.Result);
        }
        [Fact]
        public void FindByContext()
        {
            // Arrange
            string findText = "статья 1";
            // Act
            var result = FindArtikleDataAccess.FindByNameAsync(findText);

            // Assert
            Assert.NotNull(result.Result);
        }
        [Fact]
        public void FindByAuthor()
        {
            // Arrange
            string findText = "admin";
            // Act
            var result = FindArtikleDataAccess.FindByNameAsync(findText);

            // Assert
            Assert.NotNull(result.Result); ;
        }
        [Fact]
        public void FindByTopicName()
        {
            // Arrange
            string findText = "Тема";
            // Act
            var result = FindArtikleDataAccess.FindByNameAsync(findText);

            // Assert
            Assert.NotNull(result.Result);
        }

    }
}
