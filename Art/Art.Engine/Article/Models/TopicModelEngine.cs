using System;
using System.Collections.Generic;

namespace Art.Engine.Article.Models
{
    public partial class TopicModelEngine
    {
        public TopicModelEngine()
        {
            TopicArticle = new HashSet<TopicArticleEngine>();
        }

        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TopicArticleEngine> TopicArticle { get; set; }
    }
}
