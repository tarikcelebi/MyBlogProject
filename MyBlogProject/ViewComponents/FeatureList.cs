using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;
using MyBlogDomain.Entities;
using MyBlogProject.Models.AboutVMs;

namespace MyBlogProject.ViewComponents
{
    public class FeatureList : ViewComponent
    {
        private readonly IAboutService aboutService;

        public FeatureList(IAboutService aboutService)
        {
            this.aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await aboutService.GetAbouts();

            return View(values);
        }
    }
}
