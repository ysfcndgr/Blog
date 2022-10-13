using AMS.BLL.Abstract;
using AMS.Model.Relotional;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
namespace AMS.WEBUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("Admin/[Controller]/[Action]/{id?}")]
        public IActionResult Index(int page=1)
        {
            return View(_categoryService.GetAll().ToPagedList(page,10));
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _categoryService.Add(category);
            return View();
        }
    }
}
