using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.ViewComponents.Writer
{
    public class WriterNotification:ViewComponent
    {
        INotificationService _notificationService;
        public WriterNotification(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public IViewComponentResult Invoke()
        {
            var model = _notificationService.GetAll();
            return View(model);
        }
    }
}
