using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager contactManager = new ContactManager();
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(Contact p)
        {
            contactManager.BLContactAdd(p);
            return View();
        }

        public ActionResult SendBox()
        {
            var messageList = contactManager.GetAll();
            return View(messageList);
        }
        public ActionResult MessageDetails(int id)
        {
            Contact contact = contactManager.GetContactDetails(id);
            return View(contact);
        }
    }
}