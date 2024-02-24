using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;

namespace MyBlogProject.ViewComponents
{
    public class PortfolioList : ViewComponent
    {
        private readonly IPortfolioService portfolioService;

        public PortfolioList(IPortfolioService portfolioService)
        {
            this.portfolioService = portfolioService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await portfolioService.GetAllAsync();

            return View(values);
        }
    }
}
