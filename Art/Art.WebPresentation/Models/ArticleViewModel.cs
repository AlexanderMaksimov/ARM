using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Art.WebPresentation.Models
{
    public partial class ArticleViewModel
    {
        public ArticleViewModel()
        {
            TopicArticle = new HashSet<TopicsViewModel>();
            Pictures = new HashSet<PictureViewModel>();
           // UserArticle = new HashSet<UserArticleViewModel>();
        }

        public int ArticleId { get; set; }
        /// <summary>
        /// Название 
        /// </summary>
        [DisplayName("Name")]
        public string Name { get; set; }
        /// <summary>
        /// Описание статьи
        /// </summary>
        [DisplayName("Description")]
        public string Description { get; set; }
        /// <summary>
        /// Статья
        /// </summary>
        [DisplayName("Context")]
        public string Context { get; set; }

        /// <summary>
        /// Дата создания документа 
        /// </summary>
        [DisplayName("CreateDateTime")]
        public DateTime CreateDateTime { get; set; }
        /// <summary>
        /// Последная дата изменнения статьи 
        /// </summary>
        [DisplayName("UpdateDateTime")]
        public DateTime UpdateDateTime { get; set; }
        /// <summary>
        /// Рейтинг от 1 до 5 звезд 
        /// </summary>
        [DisplayName("Rating")]
        public int Rating { get; set; }
        /// <summary>
        /// Статус заблокирова статья или нет  для показа разным пользователям 
        /// </summary>
        [DisplayName("StatusVisibleUser")]
        public int StatusVisibleUser { get; set; }

        /// <summary>
        /// Статус статьи
        /// </summary>
        [DisplayName("StatusPublication")]
        public int StatusPublication { get; set; }

        /// <summary>
        /// Автор UserId
        /// </summary>
        [DisplayName("AuthorId")]
        public int AuthorId { get; set; }
        /// <summary>
        /// Автор  статьи
        /// </summary>
        [DisplayName("Author")]
        public AuthorsViewModel Author { get; set; }

        /// <summary>
        /// Соавторы
        /// </summary>
        [DisplayName("JointAuthors")]
        public string JointAuthors { get; set; }

        /// <summary>
        /// статьи пользователя 
        /// </summary>
        //[DisplayName("UserArticle")]
        //public virtual ICollection<UsersViewModel> UserArticle { get; set; }
        /// <summary>
        /// Темы статьи 
        /// </summary>
        [DisplayName("TopicArticle")]
        public virtual ICollection<TopicsViewModel> TopicArticle { get; set; }
        [DisplayName("Pictures")]
        public virtual ICollection<PictureViewModel> Pictures { get; set; }
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

