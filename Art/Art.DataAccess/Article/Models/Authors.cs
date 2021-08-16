using Art.DataAccess.User.Models;
using System;
using System.Collections.Generic;

namespace Art.DataAccess.Article.Models
{
    public partial class Authors
    {
        public Authors()
        {
            Articles = new HashSet<Articles>();
        }

        public int AuthorId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }

        public virtual Users User { get; set; }      
        public virtual ICollection<Articles> Articles { get; set; }
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
