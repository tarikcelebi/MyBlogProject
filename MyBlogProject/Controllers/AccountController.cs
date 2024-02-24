using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlogBLL.Services.Concrete;
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


        [HttpGet]
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
            if (ModelState.IsValid)
            {

            }

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
                ModelState.AddModelError(" ", "Login Failed : Email or password wrong");
            }

            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public  IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpVM user)
        {

            if (ModelState.IsValid)
            {
                AppUser newUser = new();
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.Email = user.Email;
                newUser.UserName = user.Email;
                newUser.Age = user.Age;
                newUser.ImageURL = user.ImageURL;

                IdentityResult result = await userManager.CreateAsync(newUser, user.Password);

                if (result.Succeeded)
                    return RedirectToAction("Login");
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("CreateUser", $"{item.Code} - {item.Description}");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User couldn't created");
                return RedirectToAction("Login","Account");
            }
                


            return RedirectToAction("Login");

        }

        //private async Task<IEnumerable<SelectListItem>> PopulateSubjects()
        //{
        //    AddSubject();
        //    IEnumerable<Subject> Subjects = await subjectService.GetAll();

        //    IEnumerable<SelectListItem> SubjectsList = (from p in Subjects
        //                                         select new SelectListItem
        //                                         {
        //                                             Text = p.Name,
        //                                             Value = p.Id.ToString()
        //                                         }).ToList();

        //    return SubjectsList;
        //}



    }
}
