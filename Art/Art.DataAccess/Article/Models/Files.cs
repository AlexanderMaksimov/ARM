using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art.DataAccess.Article.Models
{
    public class Files
    {
        [Key]
        public int Id { get; set; }
        public string FileType { get; set; }
        public byte[] File { get; set; }
        public virtual Articles Article { get; set; }
    }
}
