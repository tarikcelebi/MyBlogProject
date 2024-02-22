using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Abstract;

namespace MyBlogProject.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService skillService;

        public SkillController(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        public async Task<IActionResult> Index()
        {

            var values = await skillService.GetSkills();
            return View(values);
        }
    }
}
