using System;
using System.Collections.Generic;

namespace Art.WebPresentation.Models
{
    public partial class TopicArticleViewModel
    {
        public int TopicId { get; set; }
        public int ArticleId { get; set; }
        public virtual ArticleViewModel Article { get; set; }
        public virtual TopicsViewModel Topic { get; set; }
    }
}
