using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
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
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        BlogManager blogManager = new BlogManager(new EfBlogDal());
        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetAll();
            return View(categoryValues);
        }

        [AllowAnonymous]
        public PartialViewResult BlogDetailsCategoryList()
        {
            var categoryValues = categoryManager.GetAll();
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
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                categoryManager.CategoryAddBL(p);
                return RedirectToAction("AdminCategoryList");
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

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            Category category = categoryManager.FindCategory(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.EditCategory(category);
                return RedirectToAction("AdminCategoryList");
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
        public ActionResult CategoryDelete(int id)
        {
            categoryManager.DeleteCategoryBL(id);
            return RedirectToAction("AdminCategoryList");
        }
    }
}