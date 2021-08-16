using System;
using System.Collections.Generic;
using System.Text;

namespace Art.Engine.Article.Models
{
    public class FilesModelEngine
    {
        public int Id { get; set; }
        public string FileType { get; set; }
        public byte[] File { get; set; }
        public virtual ArticleModelEngine Article { get; set; }
    }
}
