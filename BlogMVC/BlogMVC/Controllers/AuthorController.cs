using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        BlogManager blogManager = new BlogManager();
        AuthorManager authorManager = new AuthorManager();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetail = blogManager.GetBlogById(id);
            return PartialView(authorDetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogAuthorId = blogManager.GetAll().Where(x => x.BlogID == id).Select(y=>y.AuthorID).FirstOrDefault();
            var authorBlogs = blogManager.GetBlogByAuthor(blogAuthorId);
            return PartialView(authorBlogs);
        }

        public ActionResult AuthorList()
        {
            var authorList=authorManager.GetAll();
            return View(authorList);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            authorManager.AddAuthorBL(author);
            return RedirectToAction("AuthorList");
        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authorManager.FindAuthor(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author author)
        {
            authorManager.EditAuthor(author);
            return RedirectToAction("AuthorList");
        }
    }
}