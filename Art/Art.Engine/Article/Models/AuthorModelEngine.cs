using Art.DataAccess.User.Models;
using Art.Engine.User.Models;
using System;
using System.Collections.Generic;

namespace Art.Engine.Article.Models
{
    public partial class AuthorModelEngine
    {
        public AuthorModelEngine()
        {
            Articles = new HashSet<ArticleModelEngine>();
        }

        public int AuthorId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }

        public virtual UsersEngine User { get; set; }      
        public virtual ICollection<ArticleModelEngine> Articles { get; set; }
    }
}
    //public partial class Authors
    //{
    //    public Authors()
    //    {
    //        AuthorArticle = new HashSet<AuthorArticle>();
    //    }

    //    public int AuthorId { get; set; }
    //    public string UserId { get; set; }
    //    public string Description { get; set; }

    //    public virtual Users User { get; set; }
    //    public virtual ICollection<AuthorArticle> AuthorArticle { get; set; }
    //}
