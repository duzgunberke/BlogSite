using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        CommentManager commentManager = new CommentManager();
       
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentList = commentManager.CommentByBlog(id);
            return PartialView(commentList); 
        }
        
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            commentManager.CommentAdd(c);
            return PartialView();
        }

        public ActionResult AdminCommentListTrue()
        {
            var commentList = commentManager.CommentByStatusTrue();
            return View(commentList);
        }

        public ActionResult AdminCommentListFalse()
        {
            var commentList = commentManager.CommentByStatusFalse();
            return View(commentList);
        }

        public ActionResult StatusChangeToFalse(int id)
        {
            commentManager.CommentStatusChangeToFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }

        public ActionResult StatusChangeToTrue(int id)
        {
            commentManager.CommentStatusChangeToTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }
    }
}