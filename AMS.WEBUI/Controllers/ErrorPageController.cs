using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}
