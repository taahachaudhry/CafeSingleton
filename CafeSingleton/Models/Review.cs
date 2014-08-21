using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeSingleton.Models
{
    public class Review
    {
        protected static int NextID = 0;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public Rating Rating { get; set; }
    }
}