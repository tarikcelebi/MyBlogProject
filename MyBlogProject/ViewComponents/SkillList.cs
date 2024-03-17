using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;
using MyBlogDomain.Entities;

namespace MyBlogProject.ViewComponents
{
    [Authorize]
    public class SkillList : ViewComponent
    {
        private readonly ISkillService skillService;
        private readonly UserManager<AppUser> userManager;

        public SkillList(ISkillService skillService, UserManager<AppUser> userManager) 
        {
            this.skillService = skillService;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {

                var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
                return View(await skillService.GetUserSkillsByUser(currentUser));

            }
            return View(await skillService.GetSkills());
        }
    }
}
