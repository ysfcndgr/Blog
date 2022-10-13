using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
