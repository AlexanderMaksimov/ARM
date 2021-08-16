using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Art.Engine.Article.Models
{
    public class PictureModelEngine
    {
        public string Id { get; set; } // название картинки
        public string ImagePath { get; set; }
        public virtual ArticleModelEngine Article { get; set; }
    }
}
