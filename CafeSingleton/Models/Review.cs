using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeSingleton.Models
{
    public class Review : Cafe
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public Rating Rating { get; set; }

        protected static int NextReviewID = 0;
        public int ReviewID { get; set; }

        public Review(int id, string name, string message, Rating rating, int ReviewID)
        {
            ID = NextID++;
            Name = name;
            Message = message;
            Rating = rating;
            ReviewID = NextReviewID++;
        }
    }
}