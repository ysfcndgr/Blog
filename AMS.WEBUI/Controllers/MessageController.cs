using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AMS.WEBUI.Controllers
{
    public class MessageController : Controller
    {
        INewMessageService _newMessageService;

        public MessageController(INewMessageService newMessageService)
        {
            _newMessageService = newMessageService;
        }
        [Authorize]
        public IActionResult Inbox()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _newMessageService.GetAll(userId);
            return View(model);
        }
        [Authorize]
        public IActionResult MessageDetails(int id)
        {
            var model = _newMessageService.GetById(id);
            return View(model);
        }
    }
}
