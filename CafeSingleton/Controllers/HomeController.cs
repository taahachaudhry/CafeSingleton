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
            cafe.ID = Cafe.NextID++;
            cafes.Add(cafe);

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Cafe cafe = cafes.Where(x => x.ID == id).FirstOrDefault();
            return View(cafe);
        }
        [HttpPost]
        public ActionResult Edit(Cafe cafe)
        {
            var c = cafes.Where(x => x.ID == cafe.ID).FirstOrDefault();
            if (c.GetType().ToString() == "CafeSingleton.Models.Cafe")
            {
                Cafe oldCafe = (Cafe)c;
                oldCafe.CafeName = cafe.CafeName;
                oldCafe.City = cafe.City;
            }
            return RedirectToAction("Details", new { id = cafe.ID });
        }
        public ActionResult Delete(int id)
        {
            var target = cafes.Where(x => x.ID == id).FirstOrDefault();
            cafes.Remove(target);

            return RedirectToAction("Index");
        }
    }
}