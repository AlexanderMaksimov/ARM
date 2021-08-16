using Art.DataAccess.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art.DataAccess.Article.Models
{
    public class UserArticle
    {
        public string UserId { get; set; }
        public int ArticleId { get; set; }
        public virtual Articles Article { get; set; }
        public virtual Users User { get; set; }
    }
}
