using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Concrete;

namespace MyBlogProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult NavBarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult FeaturePartial()
        {
            return PartialView("~/Views/Feature/FeaturePartial.cshtml");
        }

        //public async Task<PartialViewResult> FeaturePartial()
        //{
        //    var AboutList = aboutService.GetAbouts();
        //    return PartialView(AboutList);

        //}
    }
}
//123456aA
