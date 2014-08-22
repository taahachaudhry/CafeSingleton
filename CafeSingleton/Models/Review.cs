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
        public double AverageRating(List<Review> reviews)
        {
            int counter = 0;
            int r = 0;
            for (var i=0; i<reviews.Count; i++){
                r += (int)reviews[i].Rating;
                counter++;
            }
            double avg = r/counter;
            return avg;
        }
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