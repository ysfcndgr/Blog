using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.ViewComponents.Writer
{
    public class DashboardLastBlog:ViewComponent
    {
        IBlogService _blogService;
        public DashboardLastBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetAll().TakeLast(5);
            return View(values);
        }
    }
}
