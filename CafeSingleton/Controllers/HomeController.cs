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
        List<Review> reviews = Singleton.Instance.Reviews;
        public ActionResult Index()
        {
            int RandomNum = new Random().Next(cafes.Count());
            HomeIndexVM bucket = new HomeIndexVM();
            bucket.Cafes = cafes;
            bucket.FeaturedCafe = bucket.Cafes[RandomNum];
            foreach (var x in bucket.Cafes)
            {
                bucket.Reviews = reviews.Where(y => y.CafeID == x.ID).ToList();
                x.AvgRating = bucket.Reviews[0].AverageRating(bucket.Reviews);

            }
            bucket.Cafes = bucket.Cafes.OrderByDescending(x => x.AvgRating).ToList();
            return View(bucket);
        }

        public ActionResult Details(int id)
        {
            HomeIndexVM bucket = new HomeIndexVM();
            bucket.Cafes.Add(cafes.Where(x => x.ID == id).FirstOrDefault());
            bucket.Reviews = reviews.Where(x => x.CafeID == id).ToList();

            return View(bucket);
        }
        [HttpGet]
        public ActionResult AddReview(int id)
        {
            var cafe = cafes.Where(x => x.ID == id).FirstOrDefault();
            return View(cafe);
        }
        [HttpPost]
        public ActionResult AddReview(string name, string message, Rating rating, int cafeid)
        {
            Review review = new Review();
            review.Name = name;
            review.Message = message;
            review.Rating = rating;
            review.ReviewID = Review.NextReviewID++;
            review.CafeID = cafeid;
            reviews.Add(review);

            return RedirectToAction("Details", new { id = cafeid });
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
        [HttpPost]
        public ActionResult DeleteReview(int id)
        {
            var target = reviews.Where(x => x.ReviewID == id).FirstOrDefault();
            reviews.Remove(target);

            return RedirectToAction("Details", new { id = id });
        }
    }
}