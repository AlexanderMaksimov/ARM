using Art.DataAccess.Article.Interface;
using Art.DataAccess.Article.Models;
using Art.DataAccess.User.Models;
using Art.Engine.Article.Interface;
using Art.Engine.Article.Models;
using Art.Engine.User.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Art.Engine.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullCollections = true;
           // CreateMap<AuthorArticle, AuthorArticleEngine>().ReverseMap();
            CreateMap<AuthorModelEngine, Authors>().ReverseMap();
            CreateMap<TopicArticleEngine, TopicArticle>().ReverseMap();
            CreateMap<TopicModelEngine, Topics>().ReverseMap();
            CreateMap<UserArticleModelEngine, UserArticle>().ReverseMap();
            CreateMap<UsersEngine, Users>().ReverseMap();
            CreateMap<IResultEngine, IResult>().ReverseMap();
            CreateMap<ResultEngine, Result>().ReverseMap();
            CreateMap<PictureModelEngine, Pictures>().ReverseMap();
            CreateMap<PictureModelEngine[], Pictures[]>().ReverseMap();
            CreateMap<ArticleModelEngine, Articles>().ReverseMap();//.Include;
            CreateMap<ArticleModelEngine[], Articles[]>().ReverseMap();//.Include;
            //CreateMap<AspNetUserTokens, UserTokensEngine>().ReverseMap();
            //CreateMap<AspNetUserRoles, UserRolesEngine>().ReverseMap();
            //CreateMap<AspNetUserLogins, UserLoginsEngine>().ReverseMap();
            //CreateMap<AspNetUserClaims, UserClaimsEngine>().ReverseMap();
            //CreateMap<AspNetRoles, RolesEngine>().ReverseMap();
            //CreateMap<AspNetRoleClaims, RoleClaimsEngine>().ReverseMap();

        }
    }
}
