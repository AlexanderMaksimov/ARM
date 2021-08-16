using System;
using System.Collections.Generic;

namespace Art.DataAccess.Article.Models
{
    public partial class Topics
    {
        public Topics()
        {
            TopicArticle = new HashSet<TopicArticle>();
        }

        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TopicArticle> TopicArticle { get; set; }
    }
}
