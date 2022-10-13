using AMS.BLL.Abstract;
using AMS.Model.Relotional;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.Controllers
{
    public class ContactController : Controller
    {
        IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contactService.Add(contact);
            ViewBag.AlertModel = "success";
            return View();
        }
    }
}
