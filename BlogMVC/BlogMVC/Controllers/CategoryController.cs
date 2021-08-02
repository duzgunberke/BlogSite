using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager categoryManager = new CategoryManager();
        BlogManager blogManager = new BlogManager();
        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetAll();
            return View(categoryValues);
        }

        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = categoryManager.GetAll();
            var blogValues = blogManager.GetAll();

            //var totalCategoryById = blogValues.GroupBy(blog => blog.CategoryID)
            //                                  .Select(Category => new { Category.Key,                             BlogCount = Category.Count() });
           
            //ViewBag.totalCategoryById = totalCategoryById;
            return PartialView(categoryValues);
        }

        public ActionResult AdminCategoryList()
        {
            var categoryList = categoryManager.GetAll();
            return View(categoryList);
        }

        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminCategoryAdd(Category p)
        {
            categoryManager.CategoryAddBL(p);
            return RedirectToAction("AdminCategoryList");
        }

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            Category category = categoryManager.FindCategory(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            categoryManager.EditCategory(category);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryDelete(int id)
        {
            categoryManager.DeleteCategoryBL(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}