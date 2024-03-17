using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;
using MyBlogDomain.Entities;

namespace MyBlogProject.ViewComponents
{
    [Authorize]
    public class PortfolioList : ViewComponent
    {
        private readonly IPortfolioService portfolioService;
        private readonly UserManager<AppUser> userManager;

        public PortfolioList(IPortfolioService portfolioService, UserManager<AppUser> userManager)
        {
            this.portfolioService = portfolioService;
            this.userManager = userManager; 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {

                var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
                return View(await portfolioService.GetPortfoliosForUserAsync(currentUser));

            }
            return View(await portfolioService.GetWhereListAsync(p=>p.AppUser==null));
        }
    }
}
