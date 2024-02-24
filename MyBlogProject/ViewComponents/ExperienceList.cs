using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;

namespace MyBlogProject.ViewComponents
{
    public class ExperienceList : ViewComponent
    {

        private readonly IExperienceService experienceService;

        public ExperienceList(IExperienceService experienceService)
        {
            this.experienceService = experienceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await experienceService.GetAllExperienceAsync();

            return View(values);
        }
    }
}
