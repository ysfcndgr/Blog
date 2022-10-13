using AMS.BLL.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.ViewComponents
{
    public class CommentList:ViewComponent
    {
        ICommentService _commentService;
        public CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var model = _commentService.GetAll(id);
            return View(model);
        }
    }
}
