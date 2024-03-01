using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogDomain.Entities;
using MyBlogProject.Models.SkillVMs;
using System.Data;

namespace MyBlogProject.Controllers
{
    [Authorize(Roles = "StandartUser")]
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

            var values = await skillService.GetUserSkillsByUser(person);
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
            if (await skillService.AddingSkillForUser(appUser, skill) == true)
            {
                return RedirectToAction("Index");
            }


            return View();
        }


        [HttpGet]
        public async Task<IActionResult> DeleteSkill(Skill Skill)
        {
            Skill SkillToBeDeleted = await skillService.GetSkillByName(Skill.SkillName);
            AppUser person = await userManager.FindByNameAsync(User.Identity.Name);
            if (SkillToBeDeleted != null)
            {
                if (await skillService.RemoveSkillForUser(SkillToBeDeleted, person))
                    return RedirectToAction("Index");
                //else
                //{
                //    ModelState.AddModelError(" ", "Silme işlemi sırasında bir sıkıntı oluştu.");

                //}

            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditSkill(int id)
        {
            Skill skilltoBeUpdated = await skillService.GetSkillById(id);

            return View(skilltoBeUpdated);
        }

        [HttpPost]
        public async Task<IActionResult> EditSkill(Skill RevisedSkill)
        {

            AppUser person = await userManager.FindByNameAsync(User.Identity.Name);
            if (await skillService.UpdateSkillForUser(RevisedSkill, person))
            { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }


    }
}
