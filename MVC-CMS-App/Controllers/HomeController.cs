using Microsoft.AspNetCore.Mvc;
namespace MVC_CMS_App
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}