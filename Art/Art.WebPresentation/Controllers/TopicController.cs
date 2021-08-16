using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art.Engine.Article.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Art.WebPresentation.Models;

namespace Art.WebPresentation.Controllers
{
    public class TopicController : Controller
    {
        protected ITopicEngine ArticleEngineService { get; set; }
        protected IFindArtikleEngine FindArtikleEngineService { get; set; }
        protected ITopicEngine TopicEngineService { get; set; }
        public IServiceProvider Provider { get; set; }

        protected readonly ILogger Logger;
        protected IMapper Mapper;
        public TopicController(IServiceProvider provider)
        {
            Provider = provider;
            ArticleEngineService = Provider.GetService<ITopicEngine>();
            TopicEngineService = Provider.GetService<ITopicEngine>();
            FindArtikleEngineService = Provider.GetService<IFindArtikleEngine>();
            Logger = Provider.GetService<ILogger>();
            Mapper = Provider.GetService<IMapper>();
            // _dbContext = _articleEngineService.SendContext();
        }
        // GET: Topics
        
      

        // GET: Topics/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Topics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Topics/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Topics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Topics/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Topics/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}