using AMS.BLL.Abstract;
using AMS.Model.Relotional;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.ViewComponents.EmailSender
{
    public class EmailSender : ViewComponent
    {
        public IViewComponentResult Invoke(NewsLetter newsLetter)
        {
            return View(newsLetter);
        }
    }
}
