using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Istka.BlogProject.App.Entity.Entities;
using Wissen.Istka.BlogProject.App.Entity.Services;
using Wissen.Istka.BlogProject.App.Entity.UnitOfWorks;
using Wissen.Istka.BlogProject.App.Entity.ViewModels;

namespace Wissen.Istka.BlogProject.App.Service.Services
{
	public class ArticleService : IArticleService
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;
		public ArticleService(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}
		public async Task<IEnumerable<ArticleViewModel>> GetAll()
		{
			//_uow.GetRepository<Article>() -> Repository<Article> karşılık gelir.
			var list = await _uow.GetRepository<Article>().GetAllAsync();

			return _mapper.Map<List<ArticleViewModel>>(list);
		}
		public async Task Add(ArticleViewModel model)
		{
			await _uow.GetRepository<Article>().Add(_mapper.Map<Article>(model));
			await _uow.CommitAsync();	//SaveChangesAsync();
		}

		public async Task<ArticleViewModel> Get(int id)
		{
			var article = await _uow.GetRepository<Article>().GetByIdAsync(id);
			return _mapper.Map<ArticleViewModel>(article);
		}


	}
}
