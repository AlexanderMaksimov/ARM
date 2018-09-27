using BaseForTheAges.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaseForTheAges.Controllers
{
    public class HomeController : Controller
    {
        MessagesContext dbMessages = new MessagesContext();
        public ActionResult Index()
        {
            // получаем из бд все объекты Book
            IEnumerable<Message> messages = dbMessages.Messages;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.Messages = messages;
            // возвращаем представление
            return View();
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}