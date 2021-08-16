using System;
using System.Collections.Generic;

namespace Art.WebPresentation.Models
{
    public partial class TopicsViewModel
    {
        public TopicsViewModel()
        {
           // TopicArticle = new HashSet<TopicArticleViewModel>();
        }

        public int TopicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       // public bool ActionTopic { get; set; }

       // public virtual ICollection<TopicArticleViewModel> TopicArticle { get; set; }
    }
}
