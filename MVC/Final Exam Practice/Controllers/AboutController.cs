using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Final_Exam_Practice.Models;

namespace Final_Exam_Practice.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            About a = new About();
            {
                a.HeadCoach = "Lincoln Riley";
                a.BowlRecord = "29-22-1 (.567)";
                a.NationalTitles= "7(1950, 1955, 1956, 1974, 1975, 1985, 2000)";
            }

            List<About> abouts = new List<About>();
            abouts.Add(a);

            return View(abouts);
            
        }
        
    }
    
}