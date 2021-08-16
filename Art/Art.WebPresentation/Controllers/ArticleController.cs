using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Art.Engine.Article.Interface;
using Art.Engine.Article.Models;
using Art.WebPresentation.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Art.WebPresentation.Controllers
{
    public class ArticleController : Controller
    {
        protected IArtikleEngine ArticleEngineService { get; set; }
        protected IPictureEngine PictureEngineService { get; set; }
        protected ITopicEngine TopicEngineService { get; set; }
        protected IFindArtikleEngine FindArtikleEngineService { get; set; }
        public IServiceProvider Provider { get; set; }

        protected readonly ILogger Logger;
        protected IMapper Mapper;
        public ArticleController(IServiceProvider provider)
        {
            Provider = provider;
            ArticleEngineService = Provider.GetService<IArtikleEngine>();
            PictureEngineService = Provider.GetService<IPictureEngine>();
            FindArtikleEngineService = Provider.GetService<IFindArtikleEngine>();
            TopicEngineService = Provider.GetService<ITopicEngine>();
            Logger = Provider.GetService<ILogger>();
            Mapper = Provider.GetService<IMapper>();
            // _dbContext = _articleEngineService.SendContext();
        }
        // GET: Article
        public ActionResult Index()
        {
            var artiklesEng = ArticleEngineService.GetAllAsync(0,100).Result;
            var artikles = Mapper.Map<List<ArticleViewModel>>(artiklesEng);
            return View(artikles);
            //return View("~/Areas/Article/Views/Article/Index.cshtml", artikles);
        }
        public ActionResult AllArtikle()
        {
            var artiklesEng = ArticleEngineService.GetAllAsync(0, 100).Result;
            var artikles = Mapper.Map<List<ArticleViewModel>>(artiklesEng);
            var topic = new TopicsViewModel() { Name = "All artikles", Description = "For Admin", TopicId = 0 };
            ArticlesViewModel articlesViewModel = new ArticlesViewModel() { Articles = artikles, Topic = topic };
            return View("~/Views/Article/Artikles.cshtml", articlesViewModel);
        }

        public async Task<ActionResult> GetTopicArticlesAsync(TopicsViewModel topic)
        {
            ViewBag.ActiveTopicId = topic.TopicId;
            var artiklesEng = await FindArtikleEngineService.FindByTopicIdAsync(topic.TopicId);
            var artikles = Mapper.Map<List<ArticleViewModel>>(artiklesEng);
            // var topic= 
            ArticlesViewModel articlesViewModel = new ArticlesViewModel() { Articles = artikles, Topic = topic };
            //return View("~/Areas/Article/Views/Article/Index.cshtml", artikles);
            return View("~/Views/Article/Artikles.cshtml", articlesViewModel);
        }
        public async Task<ActionResult> NewTopicArtiklesAsync()
        {
            var artiklesEng = ArticleEngineService.GetAllAsync(0, 100).Result;
            var artikles = Mapper.Map<List<ArticleViewModel>>(artiklesEng);
            var topicEng = await TopicEngineService.GetFirstAsunc();
            var topic = Mapper.Map<TopicsViewModel>(topicEng);
            ArticlesViewModel articlesViewModel = new ArticlesViewModel() { Articles = artikles, Topic = topic };
            return View("~/Views/Article/Artikles.cshtml", articlesViewModel);
        }
        public ActionResult AddFile()
        {
            return View(new PictureViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> AddFileAsync(PictureViewModel file)
        {
            try
            {
                byte[] imageData = null;
                using (var memoryStream = new MemoryStream())
                {
                    await file.FormImage.CopyToAsync(memoryStream);
                    imageData = memoryStream.ToArray();
                }
                Console.WriteLine(imageData.ToString());
                PictureModelEngine picture = new PictureModelEngine();
                picture.Id = file.FormImage.FileName;
              //  picture.ImageType = file.FormImage.ContentType;
              //  picture.Image = imageData;

                var result=await PictureEngineService.AddAsync(picture);
                return Content($"<h1>{result.Succeeded}</h1>");
            }
            catch (Exception ex)
            {
                return View(ex.ToString());
            }
        }
        //public async Task<FileContentResult> GetImage(int productId)
        //{
        //    //return File(prod.ImageData, prod.ImageMimeType);
        //    var pictureEng = await PictureEngineService.GetAsync(productId);

        //   // var ty = Convert.ToBase64String(artiklesEng.FirstOrDefault().Image);
        //    PictureViewModel picture=Mapper.Map<PictureViewModel>(pictureEng);
        //    return File(pictureEng.Image, pictureEng.ImageType);
        //    //return View("~/Areas/Article/Views/Article/Index.cshtml", artikles);
        //}
        //public async Task<ActionResult> IndexFileAsync()
        //{
        //    var artiklesEng = await PictureEngineService.GetAllAsync(0, 100);

        //    var ty = Convert.ToBase64String(artiklesEng.FirstOrDefault().Image);
        //    List<PictureViewModel> pictures = new List<PictureViewModel>();
        //    foreach (var artikle in artiklesEng)
        //        pictures.Add(Mapper.Map<PictureViewModel>(artikle));
        //    return View(pictures);
        //    //return View("~/Areas/Article/Views/Article/Index.cshtml", artikles);
        //}
        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            var artiklesEng = ArticleEngineService.GetAsync(id).Result;
            var artikle = Mapper.Map<ArticleViewModel>(artiklesEng);
            return View(artikle);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Authors,Topics,Name,Description,Context")] ArticleViewModel articlesView)
        {
            try
            {
                // TODO: Add insert logic here
                var artikle = Mapper.Map<ArticleModelEngine>(articlesView);
                var artiklesEng = ArticleEngineService.AddAsync(artikle).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Article/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Authors,Topics,Name,Description,Context")] ArticleViewModel articlesView)
        {
            try
            {
                // TODO: Add update logic here
                var artikle = Mapper.Map<ArticleModelEngine>(articlesView);
                var artiklesEng = ArticleEngineService.UpdateAsync(artikle).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Article/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind("Authors,Topics,Name,Description,Context")] ArticleViewModel articlesView)
        {
            try
            {
                // TODO: Add delete logic here
                var artikle = Mapper.Map<ArticleModelEngine>(articlesView);
                var artiklesEng = ArticleEngineService.DeleteAsync(artikle).Result;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}