using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class HeaderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
