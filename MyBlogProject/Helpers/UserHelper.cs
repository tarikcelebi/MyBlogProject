using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogDomain.Entities;
using System.Security.Claims;

namespace MyBlogProject.Helpers
{
    public  class UserHelper 
    {
        private readonly UserManager<AppUser> userManager;

        public UserHelper(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<AppUser> GetCurrentUserAsync(ClaimsPrincipal user)
        {
            return await userManager.FindByNameAsync(user.Identity.Name);
        }

    }
}
