using AMS.BLL.Abstract;
using AMS.BLL.ValidationRules;
using AMS.Model.NoRelational;
using AMS.Model.Relotional;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace AMS.WEBUI.Controllers
{
    public class WriterController : Controller
    {
        IWriterService _writerService;
        IBlogService _blogService;
        ICategoryService _categoryService;
        public WriterController(IWriterService writerService, IBlogService blogService, ICategoryService categoryService)
        {
            _writerService = writerService;
            _blogService = blogService;
            _categoryService = categoryService;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public PartialViewResult WriterNavbar()
        {
            return PartialView();
        }
        [Authorize]
        public PartialViewResult WriterFooter()
        {
            return PartialView();
        }
        [Authorize]
        public IActionResult BlogListByWriter()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _blogService.GetAllForBlogListByWriter(userId);

            return View(model);
        }
        [Authorize]
        public IActionResult BlogAdd()
        {
            #region Create Category List
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.Id.ToString()
                                               }
                                               ).ToList();
            ViewBag.Categories = categories;
            #endregion Create Category List

            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult BlogAdd(Blog model)
        {
            #region Check Integrity
            BlogValidator validationRules = new BlogValidator();
            ValidationResult validationResult = validationRules.Validate(model);
            if (validationResult.IsValid)
            {
                model.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                model.WriterId =  int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                _blogService.Add(model);
                ViewBag.AlertModel = "Blog başarıyla eklendi";
                return RedirectToAction("BlogListByWriter");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.Id.ToString()
                                                   }
                                              ).ToList();
                ViewBag.Categories = categories;
            }
            #endregion Check Integrity

            return View();
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var model = _blogService.GetById(id);
            model.BlogStatus = false;
            _blogService.Update(model);
            return RedirectToAction("BlogListByWriter","Writer");
        }
        [Authorize]
        public IActionResult Update(int id)
        {
            var model = _blogService.GetById(id);
            List<SelectListItem> categories = (from x in _categoryService.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.Id.ToString()
                                               }
                                              ).ToList();
            ViewBag.Categories = categories;
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Update(Blog blog)
        {
            _blogService.Update(blog);
            return RedirectToAction("BlogListByWriter", "Writer");
        }
        [Authorize]
        public IActionResult WriterEditProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = _writerService.GetById(int.Parse(userId));
            return View(model);
        }
        [HttpPost]
        [Authorize]
        public IActionResult WriterEditProfile(Writer writer)
        {
            WriterValidator wl = new WriterValidator();
            ValidationResult results = wl.Validate(writer);
            if (results.IsValid)
            {
                if (writer.Upload!=null)
                {
                    writer.WriterImage = AddProfileImage.ImageAdd(writer.Upload);
                }
                writer.WriterStatus = true;
                _writerService.Update(writer);
                ViewBag.AlertModel = "İçerik başarıyla güncellendi";
                return View();
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorCode);
                }
            }
            return View();
        }
    }
}
