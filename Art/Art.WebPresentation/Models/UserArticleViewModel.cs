using Art.DataAccess.User.Models;
using Art.Engine.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art.WebPresentation.Models
{
    public class UserArticleViewModel
    {
        public string UserId { get; set; }
        public int ArticleId { get; set; }
        public virtual ArticleViewModel Article { get; set; }
        public virtual UsersEngine User { get; set; }
    }
}
