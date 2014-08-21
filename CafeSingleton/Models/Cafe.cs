using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeSingleton.Models
{
    public class Cafe
    {
        protected static int NextID = 0;
        public int ID { get; set; }
        public string CafeName { get; set; }
        public string City { get; set; }

        public Cafe(int id, string cafename, string city)
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