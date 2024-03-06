using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;
using MyBlogDAL.Context;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDAL.Repositories.Concrete;
using MyBlogDAL.UnitOfWork.Abstract;
using MyBlogDAL.UnitOfWork.Concrete;
using MyBlogDomain.Entities;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyBlogDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionString"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<MyBlogDbContext>();

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IExperienceService, ExperienceService>();
builder.Services.AddScoped<IEducationService, EducationService>();

builder.Services.AddScoped<IEducationRepository, EducationRepository>();
builder.Services.AddScoped<ISkillRepository, SkillRepository>();
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IExperienceRepository, ExperienceRepository>();

/*
    Singleton : uygulama ayağa kalktıkta sonra bir adet instance ile devam eder.Memory de tutulur ve çağırıldığında döndürülür.Ram olarak yorucu olabilir.

    Scoped: her request için bir instance yaratılır.

    Transient: her service çağırıldığında yeni bir intance ile devam edilir. fakat kaynak tüketimi çoktur.
 
 */

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
