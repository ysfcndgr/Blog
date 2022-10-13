using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.Controllers
{
    public class BlogController : Controller
    {
        IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var model = _blogService.GetAll();
            return View(model);
        }
        public IActionResult BlogDetails(int id)
        {
            var model = _blogService.GetById(id);
            return View(model);
        }
      
    }
}
