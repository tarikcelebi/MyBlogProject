using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;
using MyBlogDomain.Entities;
using MyBlogProject.Models.AboutVMs;

namespace MyBlogProject.ViewComponents
{
    [Authorize]
    public class FeatureList : ViewComponent
    {
        private readonly IAboutService aboutService;
        private readonly UserManager<AppUser> userManager;

        public FeatureList(IAboutService aboutService, UserManager<AppUser> userManager)
        {
            this.aboutService = aboutService;
            this.userManager = userManager;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            if (User.Identity.IsAuthenticated)
            {

                var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
                return View(await aboutService.GetUserAboutsByUser(currentUser));

            }
            return View(await aboutService.GetAboutWithOutuser());
        }
    }
}
