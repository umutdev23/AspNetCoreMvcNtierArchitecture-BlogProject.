﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Wissen.Istka.BlogProject.App.DataAccess.Identity;
using Wissen.Istka.BlogProject.App.Entity.Services;
using Wissen.Istka.BlogProject.App.Entity.ViewModels;

namespace Wissen.Istka.BlogProject.App.WebMvcUI.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService _service;

		public AccountController(IAccountService service)
		{
			_service = service;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login(string? ReturnUrl)
		{
			LoginViewModel model = new LoginViewModel()
			{
				ReturnUrl = ReturnUrl
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			string msg = await _service.FindByNameAsync(model);
			if(msg == "kullanıcı bulunamadı!")
			{
				ModelState.AddModelError("", msg);
				return View(model);
			}
			else if(msg == "OK")
			{
				return Redirect(model.ReturnUrl ?? "~/");
			}
			else
			{
				ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
			}
			return View(model);
		}

		public IActionResult Register()
		{
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
			string msg = await _service.CreateUserAsync(model);
			if(msg == "OK")
			{
				return RedirectToAction("Login");
			}
			else
			{
				ModelState.AddModelError("", msg);
			}
            return View(model);
        }
		public async Task<IActionResult> Logout()
		{
			await _service.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

	}
}
