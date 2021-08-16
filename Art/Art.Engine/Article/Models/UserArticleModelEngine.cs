using Art.DataAccess.User.Models;
using Art.Engine.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art.Engine.Article.Models
{
    public class UserArticleModelEngine
    {
        public string UserId { get; set; }
        public int ArticleId { get; set; }
        public virtual ArticleModelEngine Article { get; set; }
        public virtual UsersEngine User { get; set; }
    }
}
