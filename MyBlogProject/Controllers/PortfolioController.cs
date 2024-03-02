using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;
using MyBlogBLL.Services.Concrete;
using MyBlogDomain.Entities;
using MyBlogProject.Models.PortfolioVMs;

namespace MyBlogProject.Controllers
{
    [Authorize(Roles ="StandartUser")]
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

                NewPortfolio.ImageURL2 = $"/UserImages/{portfolioVmToBeAdded.ProjectPic2.FileName}";


                if (await portfolioService.AddPortfolioForUserByEntitiesAsync(NewPortfolio, await userManager.FindByNameAsync(portfolioVmToBeAdded.AppUserId)))
                    return RedirectToAction("Index");
                return RedirectToAction("Index");

            }
            else
                ModelState.AddModelError(" ", "Please fill the neccessary parts");


            return View();

        }
    }
}
