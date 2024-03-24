using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogDomain.Entities;

namespace MyBlogProject.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        private readonly IEducationService educationService;
        private readonly UserManager<AppUser> userManager;

        public EducationController(IEducationService educationService, UserManager<AppUser> userManager)
        {
            this.educationService = educationService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            return View(await educationService.GetUserEducationsForUser(await userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddEducation(Education education)
        {
            if (await educationService.AddingEducationForUser(await userManager.FindByNameAsync(User.Identity.Name), education))
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditEducation(int experienceId)
        {
            Education education = await educationService.GetEducationByIdASync(experienceId);

            return View(education);
        }

        [HttpPost]
        public async Task<IActionResult> EditEducation(Education UpdatedEducation)
        {
            if (await educationService.UpdateEducationForUser(UpdatedEducation, await userManager.FindByNameAsync(User.Identity.Name)))
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> RemoveExperience(int educationId)
        {
            Education education = await educationService.GetEducationByIdASync(educationId);

            if (await educationService.RemoveEducationForUser(education, await userManager.FindByNameAsync(User.Identity.Name)))
                return RedirectToAction("Index");
            return RedirectToAction("Index");


        }


    }
}
