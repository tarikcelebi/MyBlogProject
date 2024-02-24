using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;

namespace MyBlogProject.ViewComponents
{
    public class SkillList : ViewComponent
    {
        private readonly ISkillService skillService;

        public SkillList(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await skillService.GetSkills();

            return View(values);
        }
    }
}
