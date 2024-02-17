using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavBarPartial()
        {
            return PartialView();
        }
    }
}
