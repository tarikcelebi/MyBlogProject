using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogDomain.Entities;
using System.Data;

namespace MyBlogProject.Controllers
{
    [Authorize(Roles="StandartUser")]
    public class SkillController : Controller
    {
        private readonly ISkillService skillService;
        private readonly UserManager<AppUser> userManager;

        public SkillController(ISkillService skillService, UserManager<AppUser> userManager)
        {
            this.skillService = skillService;
            this.userManager = userManager;

            
        }

        public async Task<IActionResult> Index()
        {
            AppUser person = await userManager.FindByNameAsync(User.Identity.Name);

            var values = await skillService.GetSkills();
            return View(values);
        }
    }
}
