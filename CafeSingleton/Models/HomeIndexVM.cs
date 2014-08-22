using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeSingleton.Models
{
    public class HomeIndexVM
    {
        public Cafe FeaturedCafe { get; set; }
        public List<Cafe> Cafes { get; set; }
        public HomeIndexVM()
        {
            Cafes = new List<Cafe>();
            Reviews = new List<Review>();
        }
        public List<Review> Reviews { get; set; }
    }
}