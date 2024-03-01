using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogDomain.Entities;

namespace MyBlogProject.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<AppUser> UserManager;

        public BaseController(UserManager<AppUser> userManager)
        {
            UserManager = userManager;
        }

        protected async Task<AppUser> GetCurrentUserAsync()
        {
            return await UserManager.FindByNameAsync(User.Identity.Name);
        }
    }
}
