using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Istka.BlogProject.App.Entity.ViewModels;

namespace Wissen.Istka.BlogProject.App.Entity.Services
{
	public interface IArticleService
	{
		Task<IEnumerable<ArticleViewModel>> GetAll();
		Task<ArticleViewModel> Get(int id);

		Task Add(ArticleViewModel model);
	}
}
