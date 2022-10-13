using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.ViewComponents.FooterLastsBlog
{
    public class FooterLastBlog:ViewComponent
    {
        IBlogService _blogService;
        public FooterLastBlog(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _blogService.GetAll().Take(3).ToList();
            return View(model);
        }
    }
}
