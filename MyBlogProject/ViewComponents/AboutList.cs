using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;

namespace MyBlogProject.ViewComponents
{
    public class AboutList : ViewComponent
    {
        private readonly IAboutService aboutService;

        public AboutList(IAboutService aboutService)
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
