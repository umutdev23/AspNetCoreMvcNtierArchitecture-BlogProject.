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
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;
		public CategoryService(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}
		public async Task<List<CategoryViewModel>> GetAll()
		{
			var list = await _uow.GetRepository<Category>().GetAllAsync();

			return _mapper.Map<List<CategoryViewModel>>(list);
		}
	}
}
