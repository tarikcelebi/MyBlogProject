using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;
using MyBlogDomain.Entities;
using MyBlogProject.Models.AboutVMs;
using System.Linq;

namespace MyBlogProject.ViewComponents
{
    [Authorize]
    public class AboutList : ViewComponent
    {
        private readonly IAboutService aboutService;
        private readonly UserManager<AppUser> userManager;
 
        public AboutList(IAboutService aboutService, UserManager<AppUser> userManager)
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
