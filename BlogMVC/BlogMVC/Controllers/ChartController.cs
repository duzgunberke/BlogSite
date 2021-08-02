using BlogMVC.Models;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVC.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
      

        public ActionResult VisualizeResult2()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
       
        public List<BlogRatingChart> BlogList()
        {
            List<BlogRatingChart> blogRatingCharts = new List<BlogRatingChart>();
            using(var c=new Context())
            {
                blogRatingCharts = c.Blogs.Select(x => new BlogRatingChart
                {
                    BlogName = x.BlogTitle,
                    Rating = x.BlogRating
                }).ToList();
            }
            return blogRatingCharts;
        }
        public ActionResult Chart1()
        {
            return View();
        }
    } 
}