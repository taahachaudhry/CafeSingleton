using CafeSingleton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CafeSingleton.Controllers
{
    public class HomeController : Controller
    {
        List<Cafe> cafes = Singleton.Instance.Cafes;
        public ActionResult Index()
        {
            int RandomNum = new Random().Next(cafes.Count());
            HomeIndexVM bucket = new HomeIndexVM();
            bucket.Cafes = cafes;
            bucket.FeaturedCafe = bucket.Cafes[RandomNum];
            return View(bucket);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}