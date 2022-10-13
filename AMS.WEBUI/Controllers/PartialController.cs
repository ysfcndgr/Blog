using AMS.BLL.Abstract;
using AMS.Model.Relotional;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.Controllers
{
    public class PartialController : Controller
    {
        INewsLetterService _newsLetterService;
        public PartialController(INewsLetterService newsLetterService)
        {
            _newsLetterService = newsLetterService;
        }
        public IActionResult NewsLetter(NewsLetter newsLetter)
        {
            _newsLetterService.Add(newsLetter);
            return RedirectToAction("Index", "Blog");
        }
    }
}
