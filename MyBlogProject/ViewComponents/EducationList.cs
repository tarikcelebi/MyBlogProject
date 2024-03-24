using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogDAL.Repositories.Abstract;
using MyBlogDomain.Entities;

namespace MyBlogProject.ViewComponents
{
    [Authorize]
    public class EducationList : ViewComponent
    {
        private readonly IEducationRepository educationRepository;
        private readonly UserManager<AppUser> userManager;

        public EducationList(IEducationRepository educationRepository, UserManager<AppUser> userManager)
        {
            this.educationRepository = educationRepository;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {

                var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
                return View(await educationRepository.GetWhereListAsync(x=>x.AppUser==currentUser));

            }
            return View(await educationRepository.GetWhereListAsync(p => p.AppUser == null));
        }

    }
}
