using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogDomain.Entities;
using MyBlogProject.Models.AccountVMs;
using System.Security.Principal;

namespace MyBlogProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string url)
        {
            LoginVM loginVM = new();
            loginVM.ReturnUrl = url;
            return View(loginVM);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

                AppUser appUser = await userManager.FindByEmailAsync(loginVM.Email);

                if (appUser != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        bool isAdmin = await userManager.IsInRoleAsync(appUser, "Admin");
                        if (isAdmin)
                            return RedirectToAction("Index", "Home");
                        else
                            return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Login Failed : Email or password wrong");
                }
            
            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(AppUserVM user)
        {
            var hasher = new PasswordHasher<AppUser>();

            AppUser newUser = new();
            newUser.FirstName=user.FirstName;
            newUser.LastName=user.LastName;
            newUser.Age = user.Age;
            newUser.Email = user.Email;
            newUser.Subjects = user.Subjects;
            newUser.PasswordHash = hasher.HashPassword(newUser, user.Password);

            await userManager.CreateAsync(newUser);
        }

    }
}
