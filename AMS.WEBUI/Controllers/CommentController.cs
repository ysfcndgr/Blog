using AMS.BLL.Abstract;
using AMS.Model.Relotional;
using Microsoft.AspNetCore.Mvc;

namespace AMS.WEBUI.Controllers
{
    public class CommentController : Controller
    {
        ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialAddComment(int id)
        {
            ViewBag.BlogId = id;
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogId = ViewBag.BlogId;
            _commentService.Add(comment);
            return RedirectToAction("BlogDetails","Blog", new { id = ViewBag.BlogId});
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var model = _commentService.GetAll(id);
            return PartialView();
        }
    }
}
