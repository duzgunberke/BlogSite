using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager blogManager = new BlogManager(new EfBlogDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogList(int page=1)
        {
            var blogList = blogManager.GetAll().ToPagedList(page,6);
            return PartialView(blogList);
        }

        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {
            // 1. Post
            var PostTittle1 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage1 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var BlogDate1 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var BlogPostId1= blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();


            ViewBag.PostTittle1 = PostTittle1;
            ViewBag.PostImage1 = PostImage1;
            ViewBag.BlogDate1 = BlogDate1;
            ViewBag.BlogPostId1 = BlogPostId1;

            // 2. Post
            var PostTittle2 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage2 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var BlogDate2 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var BlogPostId2 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.PostTittle2 = PostTittle2;
            ViewBag.PostImage2 = PostImage2;
            ViewBag.BlogDate2 = BlogDate2;
            ViewBag.BlogPostId2 = BlogPostId2;

            // 3. Post
            var PostTittle3 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage3 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var BlogDate3 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var BlogPostId3 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.PostTittle3 = PostTittle3;
            ViewBag.PostImage3 = PostImage3;
            ViewBag.BlogDate3 = BlogDate3;
            ViewBag.BlogPostId3 = BlogPostId3;


            // 4. Post
            var PostTittle4 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage4 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogImage).FirstOrDefault();
            var BlogDate4 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogDate).FirstOrDefault();
            var BlogPostId4 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 5).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.PostTittle4 = PostTittle4;
            ViewBag.PostImage4 = PostImage4;
            ViewBag.BlogDate4 = BlogDate4;
            ViewBag.BlogPostId4 = BlogPostId4;


            // Middle Content
            var PostTittle5 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var PostImage5 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var BlogDate5 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var BlogPostId5 = blogManager.GetAll().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.PostTittle5 = PostTittle5;
            ViewBag.PostImage5 = PostImage5;
            ViewBag.BlogDate5 = BlogDate5;
            ViewBag.BlogPostId5 = BlogPostId5;


            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }


        [AllowAnonymous]
        public ActionResult BlogDetails()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = blogManager.GetBlogById(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = blogManager.GetBlogById(id);
            return PartialView(BlogDetailsList);
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var BlogListByCategory = blogManager.GetBlogByCategory(id);
            var CategoryName = blogManager.GetBlogByCategory(id).Select(X => X.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = CategoryName;
            var CategoryDescription = blogManager.GetBlogByCategory(id).Select(X => X.Category.CategoryDescription).FirstOrDefault();
            ViewBag.CategoryDescription = CategoryDescription;

            return View(BlogListByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var blogList = blogManager.GetAll();
            return View(blogList);
        }

        public ActionResult AdminBlogList2()
        {
            var blogList = blogManager.GetAll();
            return View(blogList);
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> CategoriNameDropBox=(from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text=x.CategoryName,
                                             Value=x.CategoryID.ToString()
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
                return RedirectToAction("AdminBlogList");
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

        public ActionResult DeleteBlog(int id)
        {
            blogManager.DeleteBlogBL(id);
            return RedirectToAction("AdminBlogList");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
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
            Blog blog = blogManager.FindBlog(id);
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            blogManager.UpdateBlog(p);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult GetCommentByBlog(int id)
        {
            CommentManager commentManager = new CommentManager();
            var commentList = commentManager.CommentByBlog(id);
            return View(commentList);
        }

        public ActionResult AuthorBlogList(int id)
        {
            var blogs = blogManager.GetBlogByAuthor(id);
            return View(blogs);
        }


    }
}