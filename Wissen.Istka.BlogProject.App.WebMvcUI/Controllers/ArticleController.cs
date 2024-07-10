using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wissen.Istka.BlogProject.App.Entity.Services;
using Wissen.Istka.BlogProject.App.Entity.ViewModels;

namespace Wissen.Istka.BlogProject.App.WebMvcUI.Controllers
{
	public class ArticleController : Controller
	{
		private readonly IArticleService _articleService;
		private readonly ICommentService _commentService;
		private readonly IAccountService _accountService;
		private readonly ICategoryService _categoryService;

        public ArticleController(IArticleService articleService, ICommentService commentService, IAccountService accountService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _commentService = commentService;
            _accountService = accountService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index(int? id, string? search)
		{
			var list = await _articleService.GetAll();

			if(id != null)		//id - CategoryId
			{
				list = list.Where(a => a.CategoryId == id).ToList();		
			}
			if(search != null)
			{
				list = list.Where(a => a.Title.ToLower().Contains(search.ToLower().Trim())).ToList();
			}

			return View(list);
		}
		public async Task<IActionResult> Details(int id)
		{
			ViewBag.Comments = await _commentService.GetAllByArticleId(id);
			var model = await _articleService.Get(id);

			return View(model);
		}
		[Authorize(Roles = "Author")]
		public async Task<IActionResult> Create() 
		{
			var categories = await _categoryService.GetAll();
			ViewBag.Categories = new SelectList(categories, "Id", "Name");
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(ArticleViewModel model, IFormFile formFile)
		{
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", formFile.FileName);
            var stream = new FileStream(path, FileMode.Create);
            formFile.CopyTo(stream);
			model.PictureUrl = "/images/" + formFile.FileName;
			var user = _accountService.Find(User.Identity.Name);
			model.UserId = user.Id;
			await _articleService.Add(model);
			return RedirectToAction("Index");
        }
		public async Task<IActionResult> CreateComment(string message, int id)
		{
			var user = await _accountService.Find(User.Identity.Name);
			CommentViewModel model = new()
			{
				ArticleId = id,
				Content = message,
				UserId = user.Id 
			};
			await _commentService.Add(model);
			return RedirectToAction("Index");
		}
	}
}
