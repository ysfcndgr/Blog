using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AMS.WEBUI.ViewComponents.Writer
{
    public class WriterMessageNotification:ViewComponent
    {
        INewMessageService _messageService;

        public WriterMessageNotification(INewMessageService messageService)
        {
            _messageService = messageService;
        }

        public IViewComponentResult Invoke()
        {
            //var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var model = _messageService.GetAll(1);
            return View(model);
        }
    }
}
