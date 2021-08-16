using System;
using System.Collections.Generic;

namespace Art.DataAccess.Article.Models
{
    public partial class TopicArticle
    {
        public int TopicId { get; set; }
        public int ArticleId { get; set; }
        public virtual Articles Article { get; set; }
        public virtual Topics Topic { get; set; }
    }
}
