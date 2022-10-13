using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.ViewComponents.Writer
{
    public class WriterLastBlog : ViewComponent
    {
        IBlogService _blogService;
        public WriterLastBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke(int WriterId)
        {
            var model = _blogService.GetAll(WriterId);
            return View(model);
        }
    }
}
