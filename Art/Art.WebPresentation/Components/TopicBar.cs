using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art.Engine.Article.Interface;
using AutoMapper;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Art.WebPresentation.Models;

namespace Art.WebPresentation.Components
{
    public class TopicBar : ViewComponent
    {
        protected ITopicEngine ArticleEngineService { get; set; }
        protected IFindArtikleEngine FindArtikleEngineService { get; set; }
        protected ITopicEngine TopicEngineService { get; set; }
        public IServiceProvider Provider { get; set; }

        protected readonly ILogger Logger;
        protected IMapper Mapper;
        public TopicBar(IServiceProvider provider)
        {
            Provider = provider;
            ArticleEngineService = Provider.GetService<ITopicEngine>();
            TopicEngineService = Provider.GetService<ITopicEngine>();
            FindArtikleEngineService = Provider.GetService<IFindArtikleEngine>();
            Logger = Provider.GetService<ILogger>();
            Mapper = Provider.GetService<IMapper>();            
            // _dbContext = _articleEngineService.SendContext();
        }
        //public Task<string> InvokeAsync()
        //{
        //    return Task.FromResult( $"Текущее время: {DateTime.Now.ToString("hh:mm:ss")}");
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {           
            var topicsEng = await TopicEngineService.GetAllAsync();
            var topics = Mapper.Map<List<TopicsViewModel>>(topicsEng);
            return View("Topicsscroller",topics);
        }
    }
}
