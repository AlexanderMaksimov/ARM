using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Art.DataAccess.Article.Models
{
    public class Pictures
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public virtual Articles Article { get; set; }
    }
}
