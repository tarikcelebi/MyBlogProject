using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlogProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public PartialViewResult SideBarPartialView()
        {
            return PartialView();
        }
    }
}
