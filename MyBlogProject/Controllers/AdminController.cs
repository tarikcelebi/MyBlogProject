using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    public class AdminController : Controller
    {
        public PartialViewResult SideBarPartialView()
        {
            return PartialView();
        }
    }
}
