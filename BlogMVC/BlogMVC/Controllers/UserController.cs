using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        UserProfileManager userProfileManager = new UserProfileManager();
        BlogManager blogManager = new BlogManager(new EfBlogDal());

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1(string p)
        {
            p = (string)Session["Mail"];
            var profileValues = userProfileManager.GetAuthorByMail(p);
            return PartialView(profileValues);
          
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            userProfileManager.EditAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string p)
        {
            p = (string)Session["Mail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.Mail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userProfileManager.GetBlogByAuthor(id);
            return View(blogs);
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = blogManager.FindBlog(id);
            Context c = new Context();
            List<SelectListItem> CategoriNameDropBox = (from x in c.Categories.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.CategoryName,
                                                            Value = x.CategoryID.ToString()
                                                        }).ToList();
            ViewBag.CategoriNameDropBox = CategoriNameDropBox;

            
            var AuthorNameDropBox = blog.Author.AuthorName;
            ViewBag.AuthorNameDropBox = AuthorNameDropBox;
            
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            blogManager.UpdateBlog(p);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> CategoriNameDropBox = (from x in c.Categories.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.CategoryName,
                                                            Value = x.CategoryID.ToString()
                                                        }).ToList();
            ViewBag.CategoriNameDropBox = CategoriNameDropBox;

            List<SelectListItem> AuthorNameDropBox = (from x in c.Authors.ToList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.AuthorName,
                                                          Value = x.AuthorID.ToString()
                                                      }).ToList();
            
            ViewBag.AuthorNameDropBox = AuthorNameDropBox;
            
            return View();
        }

        [HttpPost]
        public ActionResult AddNewBlog(Blog b)
        {
            BlogValidator blogValidator = new BlogValidator();
            ValidationResult results = blogValidator.Validate(b);
            if (results.IsValid)
            {
                blogManager.BlogAddBL(b);
                return RedirectToAction("BlogList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }

        public ActionResult LogOut2()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }

    }
}