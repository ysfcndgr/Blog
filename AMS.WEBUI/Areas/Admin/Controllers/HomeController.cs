using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
