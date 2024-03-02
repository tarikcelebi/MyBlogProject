using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogDomain.Entities;
using MyBlogProject.Models.AboutVMs;

namespace MyBlogProject.Controllers
{
    [Authorize(Roles = ("StandartUser"))]
    public class AboutController : Controller
    {
        private readonly IAboutService aboutService;
        private readonly UserManager<AppUser> userManager;

        public AboutController(IAboutService aboutService, UserManager<AppUser> userManager)
        {
            this.aboutService = aboutService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var About = await aboutService.GetUserAboutByUser(await userManager.FindByNameAsync(User.Identity.Name));

            return View(About);
        }


        public async Task<IActionResult> AddAbout()
        {
            if (aboutService.checkAbout(await userManager.FindByNameAsync(User.Identity.Name)))
                return RedirectToAction("EditAbout");
                
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAbout(AddAboutVM aboutVM)
        {
            if (ModelState.IsValid)
            {

                About NewAbout = new();
                NewAbout.AppUser = await userManager.FindByNameAsync(aboutVM.AppUserId);
                NewAbout.Title = aboutVM.Title;
                NewAbout.Description = aboutVM.Description;
                NewAbout.Age = aboutVM.Age;
                NewAbout.Name = aboutVM.Name;
                NewAbout.Phone = aboutVM.Phone;
                NewAbout.Mail = User.Identity.Name;
                if (aboutVM.ProfilePic != null && aboutVM.ProfilePic.Length > 0)
                {

                    var filePath = Path.Combine("wwwroot/UserImages", aboutVM.ProfilePic.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        aboutVM.ProfilePic.CopyTo(stream);
                    }

                    NewAbout.ImageURL = $"/UserImages/{aboutVM.ProfilePic.FileName}";
                }

                if (await aboutService.AddAboutByUser(NewAbout))
                    return RedirectToAction("Index");
                return RedirectToAction("Index");

            }
            else
                ModelState.AddModelError(" ", "Please fill the neccessary parts");


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditAbout(int aboutId)
        {
            About aboutToBeEditted = await aboutService.GetAboutById(aboutId);

            return View(aboutToBeEditted);
        }

        [HttpPost]
        public async Task<IActionResult> EditAbout(About EdittingAbout)
        {
            if (await aboutService.UpdateAboutForUser(EdittingAbout, await userManager.FindByNameAsync(User.Identity.Name)))
                return RedirectToAction("Index");

            return RedirectToAction("Index");
        }
       
        public async Task<IActionResult> RemoveAbout(int aboutId)
        {
            About about = await aboutService.GetAboutById(aboutId);

            if (await aboutService.RemoveAboutForUser(about, await userManager.FindByNameAsync(User.Identity.Name)))
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
    }
}
