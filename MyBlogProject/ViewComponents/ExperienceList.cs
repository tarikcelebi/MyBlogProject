using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;
using MyBlogDomain.Entities;

namespace MyBlogProject.ViewComponents
{
    [Authorize]
    public class ExperienceList : ViewComponent
    {

        private readonly IExperienceService experienceService;
        private readonly UserManager<AppUser> userManager;

        public ExperienceList(IExperienceService experienceService, UserManager<AppUser> userManager)
        {
            this.experienceService = experienceService;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {

                var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
                return View(await experienceService.GetWhereListAsync(x=>x.AppUser==currentUser));

            }
            return View(await experienceService.GetWhereListAsync(x=>x.AppUser==null));
        }
    }
}
