using Microsoft.EntityFrameworkCore;
using System;
using Wissen.Istka.BlogProject.App.DataAccess.Contexts;
using Wissen.Istka.BlogProject.App.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogDbContext>(
        options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")
    ));

builder.Services.AddExtensions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();       //wwwroot klasörünü tanýyor.

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
      name: "areas",
      pattern: "{controller=Home}/{action=Index}/{id?}/{area=Admin}"
    );

app.MapControllerRoute(
      name: "area",
      pattern: "{controller=Home}/{action=Index}/{area=Admin}"
    );



app.Run();
