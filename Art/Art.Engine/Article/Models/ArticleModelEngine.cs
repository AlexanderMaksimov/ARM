using Art.DataAccess.User.Models;
using System;
using System.Collections.Generic;

namespace Art.Engine.Article.Models
{
    public partial class ArticleModelEngine
    {
        public ArticleModelEngine()
        {
            TopicArticle = new HashSet<TopicArticleEngine>();
            UserArticle = new HashSet<UserArticleModelEngine>();
            Pictures = new HashSet<PictureModelEngine>();
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
        public AuthorModelEngine Author { get; set; }

        /// <summary>
        /// Соавторы
        /// </summary>
        public string JointAuthors { get; set; }

        /// <summary>
        /// статьи пользователя 
        /// </summary>
        public virtual ICollection<UserArticleModelEngine> UserArticle { get; set; }
        public virtual ICollection<PictureModelEngine> Pictures { get; set; }
        public virtual ICollection<FilesModelEngine> Files { get; set; }

        /// <summary>
        /// Темы статьи 
        /// </summary>
        public virtual ICollection<TopicArticleEngine> TopicArticle { get; set; }

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

