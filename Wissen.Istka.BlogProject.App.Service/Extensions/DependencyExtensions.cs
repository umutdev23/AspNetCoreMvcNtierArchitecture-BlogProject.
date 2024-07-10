using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wissen.Istka.BlogProject.App.DataAccess.Contexts;
using Wissen.Istka.BlogProject.App.DataAccess.Identity;
using Wissen.Istka.BlogProject.App.DataAccess.Repositories;
using Wissen.Istka.BlogProject.App.DataAccess.UnitOfWorks;
using Wissen.Istka.BlogProject.App.Entity.Repositories;
using Wissen.Istka.BlogProject.App.Entity.Services;
using Wissen.Istka.BlogProject.App.Entity.UnitOfWorks;
using Wissen.Istka.BlogProject.App.Service.Mapping;
using Wissen.Istka.BlogProject.App.Service.Services;

namespace Wissen.Istka.BlogProject.App.Service.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddExtensions(this IServiceCollection services) 
        {
            services.AddIdentity<AppUser, AppRole>(
    opt =>
    {
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequiredLength = 3;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireDigit = false;

        opt.User.RequireUniqueEmail = true;  //aynı email adresinin girilmesine izin vermez.

        //opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyzqw0123456789";  //Kullanıcı adı girilirken sadece bu karakterlere izin verir.

        opt.Lockout.MaxFailedAccessAttempts = 3; //default=5
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default=5
    }
).AddEntityFrameworkStores<BlogDbContext>();

        services.ConfigureApplicationCookie(opt =>
        {
            opt.LoginPath = new PathString("/Account/Login");
            opt.LogoutPath = new PathString("/Account/Logout");
            //opt.AccessDeniedPath = new PathString("/Account/AccessDenied");
            opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            opt.SlidingExpiration = true; //10 dk. dolmadan kullanıcı yeniden login olursa süre baştan başlar.

            opt.Cookie = new CookieBuilder()
            {
                Name = "Identity.App.Cookie",
                HttpOnly = true
            };
        });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
			services.AddScoped(typeof(IAccountService), typeof(AccountService));

			services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
