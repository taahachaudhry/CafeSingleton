using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeSingleton.Models
{
    public class Cafe
    {
        public static int NextID = 0;
        public int ID { get; set; }
        public string CafeName { get; set; }
        public string City { get; set; }
        public double AvgRating { get; set; }
        public Cafe(string cafename, string city)
        {
            ID = NextID++;
            CafeName = cafename;
            City = city;
        }
        public Cafe()
        {

        }
    }
}