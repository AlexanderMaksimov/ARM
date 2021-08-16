using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Art.DataAccess.Article.Models
{
    public static class ArticleArtDbInitializer 
    {
        public static void Initialize(ArticleDbContext db)
        {
            if (!db.Articles.Any())
            {
                db.Authors.Add(new Authors { UserId = "e847bb57-bfc8-4c46-985b-e35e82ea7b7a" ,Description="TestAuthor"});
                //db.Authors.Add(new Authors { Name = "Endi" });
                //db.Authors.Add(new Authors { Name = "Ardi" });
                db.Topics.Add(new Topics { Name = "API", Description = "ViewTopic" });
                db.Topics.Add(new Topics { Name = "Red", Description = "RedTopic" });
                db.Articles.Add(
                    new Articles
                    {
                        Name = "Fluent API Configuration",
                        Context = "Configurations are applied via a number of methods exposed by the Microsoft.EntityFrameworkCore.ModelBuilder class. The DbContext class has a method called OnModelCreating that takes an instance of ModelBuilder as a parameter. This method is called by the framework when your context is first created to build the model and its mappings in memory. You can override this method to add your own configurations:",
                        Description = "EF Core's Fluent API provides methods for configuring various aspects of your model:",      
                    });
                db.SaveChanges();
               // db.AuthorArticle.Add(new AuthorArticle { Article = db.Articles.FirstOrDefault(), Author = db.Authors.FirstOrDefault() });
                db.TopicArticle.Add(new TopicArticle { Article = db.Articles.FirstOrDefault(), Topic = db.Topics.FirstOrDefault() });
                db.SaveChanges();
            }
        }
    }
}