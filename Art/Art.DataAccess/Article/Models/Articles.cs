using Art.DataAccess.User.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Art.DataAccess.Article.Models
{
    public partial class Articles
    {
        public Articles()
        {
            //AuthorArticle = new HashSet<AuthorArticle>();
            TopicArticle = new HashSet<TopicArticle>();
            UserArticle = new HashSet<UserArticle>();
            Pictures = new HashSet<Pictures>();
        }

        public int ArticleId { get; set; }
        /// <summary>
        /// Название 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание статьи
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Статья
        /// </summary>
        public string Context { get; set; }

        /// <summary>
        /// Дата создания документа 
        /// </summary>
        public DateTime CreateDateTime { get; set; }
        /// <summary>
        /// Последная дата изменнения статьи 
        /// </summary>
        public DateTime UpdateDateTime { get; set; }
        /// <summary>
        /// Рейтинг от 1 до 5 звезд 
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// Статус заблокирова статья или нет  для показа разным пользователям 
        /// </summary>
        public int StatusVisibleUser { get; set; }

        /// <summary>
        /// Статус статьи
        /// </summary>
        public int StatusPublication { get; set; }

        /// <summary>
        /// Автор UserId
        /// </summary>
        public int AuthorId { get; set; }
        /// <summary>
        /// Автор  статьи
        /// </summary>
        public Authors Author { get; set; }

        /// <summary>
        /// Соавторы
        /// </summary>
        public string JointAuthors { get; set; }

        /// <summary>
        /// статьи пользователя 
        /// </summary>
        public virtual ICollection<UserArticle> UserArticle { get; set; }
        /// <summary>
        /// Темы статьи 
        /// </summary>
        public virtual ICollection<TopicArticle> TopicArticle { get; set; }

        public virtual ICollection<Files> Files { get; set; }
        public virtual ICollection<Pictures> Pictures { get; set; }
        public enum StatusVisible
        {
            //видно всем 
            VisibleAll = 0,
            //видно зарегестрированным пользователям
            VisibleRgistered = 1,
            //видно администратору
            VisibleAdmin = 2,
            //не видно никому
            VisibleDissable = 3,
            //видно группе
            VisibleGroup = 4,
        }
        public enum StatusArticle
        {
            /// <summary>
            /// Не отправленна
            /// </summary>
            NotSent = 0,
            /// <summary>
            /// В очереди на проверку
            /// </summary>
            LineForChecked = 1,
            /// <summary>
            /// Проверяется
            /// </summary>
            StartСhecked = 2,
            /// <summary>
            /// Проверенно
            /// </summary>
            Checked = 3,
            /// <summary>
            /// Исправляется 
            /// </summary>
            Сorrected = 4,
            /// <summary>
            /// Опубликованна
            /// </summary>
            Published = 5,
            /// <summary>
            /// Заблокированна
            /// </summary>
            Blocked = 6,
        }
    }

}


//using Art.DataAccess.User.Models;
//using System;
//using System.Collections.Generic;

//namespace Art.DataAccess.Article.Models
//{
//    public partial class Articles
//    {
//        public Articles()
//        {
//            AuthorArticle = new HashSet<AuthorArticle>();
//            TopicArticle = new HashSet<TopicArticle>();
//            UserArticle = new HashSet<UserArticle>();
//        }

//        public int ArticleId { get; set; }
//        /// <summary>
//        /// Название 
//        /// </summary>
//        public string Name { get; set; }
//        /// <summary>
//        /// Описание статьи
//        /// </summary>
//        public string Description { get; set; }
//        /// <summary>
//        /// Статья
//        /// </summary>
//        public string Context { get; set; }

//        /// <summary>
//        /// Дата создания документа 
//        /// </summary>
//        public DateTime CreateDateTime { get; set; }
//        /// <summary>
//        /// Последная дата изменнения статьи 
//        /// </summary>
//        public DateTime UpdateDateTime { get; set; }
//        /// <summary>
//        /// Рейтинг от 1 до 5 звезд 
//        /// </summary>
//        public int Rating { get; set; }
//        /// <summary>
//        /// Статус заблокирова статья или нет  для показа разным пользователям 
//        /// </summary>
//        public int StatusVisibleUser { get; set; }

//        /// <summary>
//        /// Статус статьи
//        /// </summary>
//        public int StatusPublication { get; set; }

//        /// <summary>
//        /// Автор  статьи
//        /// </summary>
//        public Users User { get; set; }
//        /// <summary>
//        /// статьи пользователя 
//        /// </summary>
//        public virtual ICollection<UserArticle> UserArticle { get; set; }
//        /// <summary>
//        /// Соавторы
//        /// </summary>
//        public virtual ICollection<AuthorArticle> AuthorArticle { get; set; }
//        /// <summary>
//        /// Темы статьи 
//        /// </summary>
//        public virtual ICollection<TopicArticle> TopicArticle { get; set; }

//        public enum StatusVisible
//        {
//            //видно всем 
//            VisibleAll = 0,
//            //видно зарегестрированным пользователям
//            VisibleRgistered = 1,
//            //видно администратору
//            VisibleAdmin = 2,
//            //не видно никому
//            VisibleDissable = 3,
//            //видно группе
//            VisibleGroup = 4,
//        }
//        public enum StatusArticle
//        {
//            /// <summary>
//            /// Не отправленна
//            /// </summary>
//            NotSent = 0,
//            /// <summary>
//            /// В очереди на проверку
//            /// </summary>
//            LineForChecked = 1,
//            /// <summary>
//            /// Проверяется
//            /// </summary>
//            StartСhecked = 2,
//            /// <summary>
//            /// Проверенно
//            /// </summary>
//            Checked = 3,
//            /// <summary>
//            /// Исправляется 
//            /// </summary>
//            Сorrected = 4,
//            /// <summary>
//            /// Опубликованна
//            /// </summary>
//            Published = 5,
//            /// <summary>
//            /// Заблокированна
//            /// </summary>
//            Blocked = 6,
//        }
//    }

//}
