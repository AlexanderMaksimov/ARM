using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Art.WebPresentation.Models
{
    public class ArticlesViewModel
    {
        public virtual ICollection<ArticleViewModel> Articles { get; set; }
        public TopicsViewModel Topic { get; set; }
    }
}
