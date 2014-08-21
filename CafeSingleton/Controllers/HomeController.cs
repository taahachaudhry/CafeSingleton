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

        public ActionResult Details(int id)
        {
            Cafe cafe = cafes.Where(x => x.ID == id).FirstOrDefault();

            return View(cafe);
        }
        [HttpGet]
        public ActionResult AddCafe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCafe(string name, string city)
        {
            Cafe cafe = new Cafe();
            cafe.CafeName = name;
            cafe.City = city;
            cafes.Add(cafe);

            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}