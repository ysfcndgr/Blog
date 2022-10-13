using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {
        ICategoryService _categoryService;
        public CategoryList(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _categoryService.GetAll();
            return View(model);
        }
    }
}
