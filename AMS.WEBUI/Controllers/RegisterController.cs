using AMS.BLL.Abstract;
using AMS.BLL.ValidationRules;
using AMS.Model.Relotional;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.Controllers
{
    public class RegisterController : Controller
    {
        IWriterService _writerService;
        public RegisterController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer model)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult validationResult = validationRules.Validate(model);
            if (validationResult.IsValid)
            {
                model.WriterStatus = true;
                _writerService.Add(model);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();           
        }
    }
}
