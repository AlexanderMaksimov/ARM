using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;
using Art.DataAccess.User.Models;
using Art.Engine.Article.Interface;
using Art.Engine.Article.Models;
using Art.Engine.User.Models;
using Art.WebPresentation.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Art.WebPresentation.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullCollections = true; 

            // CreateMap<AuthorArticle, AuthorArticleEngine>().ReverseMap();
            CreateMap<AuthorModelEngine, AuthorsViewModel>().ReverseMap();
            CreateMap<TopicArticleEngine, TopicArticleViewModel>().ReverseMap();
            CreateMap<TopicModelEngine, TopicsViewModel>().ReverseMap();
            CreateMap<TopicModelEngine[], TopicsViewModel[]>().ReverseMap();
            CreateMap<UserArticleModelEngine, UserArticleViewModel>().ReverseMap();
            CreateMap<UsersEngine, UsersViewModel>().ReverseMap();
            CreateMap<Users, UsersViewModel>().ReverseMap();
            CreateMap<PictureModelEngine, PictureViewModel>().ReverseMap();
            //CreateMap<PictureModelEngine, PictureViewModel>().ForMember(dest => dest.Image,
            //                opt => opt.MapFrom(z => Convert.ToBase64String(z.Image)));
            //CreateMap<PictureViewModel, PictureModelEngine>().ForMember(dest => dest.Image,
            //                opt => opt.MapFrom(z => Encoding.Default.GetBytes(z.Image)));
            CreateMap<PictureViewModel[], PictureModelEngine[]>();
            CreateMap<PictureModelEngine[], PictureViewModel[]>();
            CreateMap<Source, Destination>()
            .ForMember(dest => dest.ValuesID, opt => opt.MapFrom<CustomResolver>());

            CreateMap<ArticleModelEngine, ArticleViewModel>()
                 .ForMember(dest => dest.TopicArticle,
                            opt => opt.MapFrom<ArticlesViewModelResolver>());
            CreateMap<ArticleViewModel, ArticleModelEngine>()
                .ForMember(dest => dest.TopicArticle,
                           opt => opt.MapFrom<ArticlesEngineResolver>());
            CreateMap<ArticleModelEngine[], ArticleViewModel[]>().ReverseMap();//.Include;
                                                           
        }
    }
    public class ArticlesViewModelResolver : IValueResolver<ArticleModelEngine, ArticleViewModel, ICollection<TopicsViewModel>>
    {
        public ICollection<TopicsViewModel> Resolve(ArticleModelEngine source, ArticleViewModel destination, ICollection<TopicsViewModel> destMember, ResolutionContext context)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TopicModelEngine, TopicsViewModel>();
                cfg.CreateMap<TopicModelEngine[], TopicsViewModel[]>();
            });

            var mapper = new Mapper(config);
            List<TopicsViewModel> topicsViews = new List<TopicsViewModel>();
            foreach (var topics in source.TopicArticle)
            { topicsViews.Add(mapper.Map<TopicsViewModel>(topics.Topic)); }
            return topicsViews;
            //throw new NotImplementedException();
        }
    }
    public class ArticlesEngineResolver : IValueResolver<ArticleViewModel, ArticleModelEngine, ICollection<TopicArticleEngine>>
    {
        public ICollection<TopicArticleEngine> Resolve(ArticleViewModel source, ArticleModelEngine destination, ICollection<TopicArticleEngine> destMember, ResolutionContext context)
        {
            List<TopicArticleEngine> topicsViews = new List<TopicArticleEngine>();
            foreach (var topic in source.TopicArticle)
            {
                TopicArticleEngine topicEng = new TopicArticleEngine()
                {
                    ArticleId = source.ArticleId,
                    TopicId = topic.TopicId
                };
                topicsViews.Add(topicEng); 
            }
            return topicsViews;
        }
    }

    public class Source
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }

    public class Destination
    {
        public int Total { get; set; }
        public ICollection<ArtList> ValuesID { get; set; }
    }
    public class ArtList
    {
        public int id { get; set; }
    }
    public class CustomResolver : IValueResolver<Source, Destination, ICollection<ArtList>>
    {
        public ICollection<ArtList> Resolve(Source source, Destination destination, ICollection<ArtList> member, ResolutionContext context)
        {
            return new List<ArtList>();
        }
    }
}
