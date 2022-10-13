using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.ViewComponents.Writer
{
    public class DashboardWriterLastBlog:ViewComponent
    {
        IBlogService _blogService;
        public DashboardWriterLastBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var model = _blogService.GetAllForBlogListByWriter(id).Take(5);
            return View(model);
        }
    }
}
