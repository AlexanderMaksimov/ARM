using System;
using System.Collections.Generic;

namespace Art.Engine.Article.Models
{
    public partial class TopicArticleEngine
    {
        public int TopicId { get; set; }
        public int ArticleId { get; set; }
        public virtual ArticleModelEngine Article { get; set; }
        public virtual TopicModelEngine Topic { get; set; }
    }
}
