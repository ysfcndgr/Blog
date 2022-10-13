using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AMS.WEBUI.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        IBlogService _blogService;
        public DashboardController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            ViewBag.UserId = userId;
            ViewBag.AllBlogCount = _blogService.GetAll().Count;
            ViewBag.WriterCount = _blogService.GetAllForBlogListByWriter(userId).Count;
            ViewBag.LastWeek = _blogService.GetAll().Where(x => x.BlogCreateDate > DateTime.Now.AddDays(-7)).Count();
            return View();
        }
    }
}
