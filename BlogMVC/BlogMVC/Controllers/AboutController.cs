using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        // GET: About
        AboutManager aboutManager = new AboutManager();
        public ActionResult Index()
        {
            var AboutContent = aboutManager.GetAll();
            return View(AboutContent);
           
        }

        public PartialViewResult Footer()
        {
            var AboutContentList=aboutManager.GetAll();
            return PartialView(AboutContentList);
        }
        
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager authorManager = new AuthorManager();
            var AuthorList = authorManager.GetAll();
            return PartialView(AuthorList);
        }
        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var abotList = aboutManager.GetAll();
            return View(abotList);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            aboutManager.UpdateAboutBM(p);
            return RedirectToAction("UpdateAboutList");
        }
    }
}