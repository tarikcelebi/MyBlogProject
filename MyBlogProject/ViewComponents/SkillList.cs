using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogDomain.Entities;

namespace MyBlogProject.ViewComponents
{
    [AllowAnonymous]
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
            AppUser user = await userManager.FindByNameAsync(User.Identity.Name);
            var values = await skillService.GetUserSkillsByUser(user);

            return View(values);
        }
    }
}
