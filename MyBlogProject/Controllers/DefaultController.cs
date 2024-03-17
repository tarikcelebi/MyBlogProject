using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlogBLL.Services.Concrete;

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

        [HttpGet]
        public PartialViewResult PopUpPartial()
        {
            return PartialView();
        }

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
