using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeSingleton.Models
{
    public class Review
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public Rating Rating { get; set; }

        public static int NextReviewID = 0;
        public int ReviewID { get; set; }
        public int CafeID { get; set; }
        public Review(string name, string message, Rating rating, int cafeid)
        {
            Name = name;
            Message = message;
            Rating = rating;
            ReviewID = NextReviewID++;
            CafeID = cafeid;
        }
        public Review() 
        {

        }
    }
}