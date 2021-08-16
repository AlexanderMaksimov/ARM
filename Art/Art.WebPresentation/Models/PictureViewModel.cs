using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Art.WebPresentation.Models
{
    public class PictureViewModel
    {
        public string Id { get; set; } // название картинки
        public string ImagePath { get; set; }
        public virtual ArticleViewModel Article { get; set; }
        public IFormFile FormImage { set; get; }
    }
}
