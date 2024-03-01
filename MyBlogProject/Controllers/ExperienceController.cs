using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;
using MyBlogDomain.Entities;
using MyBlogProject.Helpers;

namespace MyBlogProject.Controllers
{
    [Authorize(Roles ="StandartUser")]
    public class ExperienceController : Controller
    {
        private readonly IExperienceService eService;
        //private readonly UserHelper _userHelper;
        private readonly UserManager<AppUser> userManager;

        public ExperienceController(IExperienceService eService, UserManager<AppUser> userManager)
        {
            this.eService=eService;
            this.userManager = userManager;
            //this._userHelper = _userHelper;
        }

        public async Task<IActionResult> Index()
        {
            
            return View(await eService.GetUserExperiencesForUser( await userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpGet]
        public  IActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExperience(Experience experience)
        {
            if (await eService.AddingExperienceForUser(await userManager.FindByNameAsync(User.Identity.Name), experience))
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditExperience(int experienceId)
        {
            Experience experience = await eService.GetExperienceByIdASync(experienceId);

            return View(experience);
        }

        [HttpPost]
        public async Task<IActionResult> EditExperience(Experience UpdatedExperience)
        {
            if (await eService.UpdateExperienceForUser(UpdatedExperience, await userManager.FindByNameAsync(User.Identity.Name)))
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> RemoveExperience(int experienceId)
        {
            Experience experience = await eService.GetExperienceByIdASync(experienceId);

            if (await eService.RemoveExperienceForUser(experience, await userManager.FindByNameAsync(User.Identity.Name)))
                return RedirectToAction("Index");
            return RedirectToAction("Index");


        }


    }
}
