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

            var values = await skillService.GetUserSkillByUser(person);
            return View(values);
        }

        public async Task<IActionResult> AddSkill()
        {
            Skill nw = new Skill();
            return View(nw);
        }

        [HttpPost]
        public async Task<IActionResult> AddSkill(Skill skill)
        {

            AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);
            //Skill newSkill = new Skill();
            //newSkill.SkillName = skill.SkillName;
            //newSkill.Level = skill.Level;
            if(await skillService.AddingSkillForUser(appUser, skill) == true)
            {
                return RedirectToAction("Index");
            }


            return View();
        }
    }
}
