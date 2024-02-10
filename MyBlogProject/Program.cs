using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlogBLL.Services.Concrete;
using MyBlogDAL.Context;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDAL.Repositories.Concrete;
using MyBlogDomain.Entities;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyBlogDbContext>(options =>
    options.UseSqlServer("connectionString"));
builder.Services.AddDbContext<AppUserDbContext>(options =>
    options.UseSqlServer("connectionString"));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MyBlogDbContext>();



builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();

builder.Services.AddScoped<SubjectService>();


builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<SignInManager<AppUser>>();
//builder.Services.AddScoped<PasswordHasher<AppUser>>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
