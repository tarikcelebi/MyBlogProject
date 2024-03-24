using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;
using MyBlogDomain.Entities;
using MyBlogProject.Models.PortfolioVMs;

namespace MyBlogProject.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IPortfolioService portfolioService;

        public PortfolioController(UserManager<AppUser> userManager, IPortfolioService portfolioService)
        {
            this.userManager = userManager;
            this.portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await portfolioService.GetPortfoliosForUserAsync(await userManager.FindByNameAsync(User.Identity.Name));
            return View(values);
        }

        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(AddPortfolioVM portfolioVmToBeAdded)
        {
            if (ModelState.IsValid)
            {

                Portfolio NewPortfolio = new();
                NewPortfolio.AppUser = await userManager.FindByNameAsync(portfolioVmToBeAdded.AppUserId);
                NewPortfolio.Name = portfolioVmToBeAdded.Name;
                NewPortfolio.ProjectUrl = portfolioVmToBeAdded.ProjectUrl;

                var filePath = Path.Combine("wwwroot/UserImages", portfolioVmToBeAdded.ProjectPic.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    portfolioVmToBeAdded.ProjectPic.CopyTo(stream);
                }

                NewPortfolio.ImageURL = $"/UserImages/{portfolioVmToBeAdded.ProjectPic.FileName}";

                var filePath2 = Path.Combine("wwwroot/UserImages", portfolioVmToBeAdded.ProjectPic2.FileName);

                using (var stream = new FileStream(filePath2, FileMode.Create))
                {
                    portfolioVmToBeAdded.ProjectPic2.CopyTo(stream);
                }


                if (await portfolioService.AddPortfolioForUserByEntitiesAsync(NewPortfolio, await userManager.FindByIdAsync(portfolioVmToBeAdded.AppUserId)))
                    return RedirectToAction("Index");
                return RedirectToAction("Index");

            }
            else
                ModelState.AddModelError(" ", "Please fill the neccessary parts");


            return View();

        }

        [HttpGet]
        public async Task<IActionResult> DeletePortfolio(int portfolioId)
        {
            if (ModelState.IsValid)
            {
                Portfolio portfolio = await portfolioService.GetPortfolioByIdASync(portfolioId);
                if (await portfolioService.RemovePortfolioFromUserListByEntitiesAsync(portfolio, await userManager.FindByNameAsync(User.Identity.Name)))
                    return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Something went wrong please try again if it continuos contact the help center.");
            return RedirectToAction("Index");


        }
        [HttpGet]
        public async Task<IActionResult> EditPortfolio(int portfolioId)
        {
            Portfolio portfolio = await portfolioService.GetPortfolioByIdASync(portfolioId);
            return View(portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> EditPortfolio(Portfolio portfolioTobeUpdated)
        {
            if (ModelState.IsValid)
            {
                if (await portfolioService.UpdatePortfolioForUserAsync(portfolioTobeUpdated, await userManager.FindByNameAsync(User.Identity.Name)))
                    return RedirectToAction("Index");

            }
            ModelState.AddModelError("", "Something went wrong!");
            return View();


        }
    }
}
