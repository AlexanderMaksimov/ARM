
using Art.WebPresentation.Models;
using System.Collections.Generic;

namespace Art.WebPresentation.Models
{
    public partial class AuthorsViewModel
    {
        public AuthorsViewModel()
        {
          //  Articles = new HashSet<ArticleViewModel>();
        }

        public int AuthorId { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }

        public virtual UsersViewModel User { get; set; }      
       // public virtual ICollection<ArticleViewModel> Articles { get; set; }
    }
}
    //public partial class Authors
    //{
    //    public Authors()
    //    {
    //        AuthorArticle = new HashSet<AuthorArticle>();
    //    }

    //    public int AuthorId { get; set; }
    //    public string UserId { get; set; }
    //    public string Description { get; set; }

    //    public virtual Users User { get; set; }
    //    public virtual ICollection<AuthorArticle> AuthorArticle { get; set; }
    //}
