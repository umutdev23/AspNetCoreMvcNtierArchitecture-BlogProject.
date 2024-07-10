using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Istka.BlogProject.App.DataAccess.Identity;
using Wissen.Istka.BlogProject.App.Entity.Entities;
using Wissen.Istka.BlogProject.App.Entity.ViewModels;

namespace Wissen.Istka.BlogProject.App.Service.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile() 
		{
			CreateMap<Article, ArticleViewModel>().ReverseMap();
			CreateMap<Category, CategoryViewModel>().ReverseMap();
			CreateMap<Comment, CommentViewModel>().ReverseMap();
			CreateMap<AppUser, UserViewModel>().ReverseMap();
			CreateMap<AppUser, LoginViewModel>().ReverseMap();
			CreateMap<AppRole, RoleViewModel>().ReverseMap();

        }
	}
}
