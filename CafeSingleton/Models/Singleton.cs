using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeSingleton.Models
{
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        public List<Cafe> Cafes { get; set; }
        static Singleton()
        {

        }
        private Singleton()
        {
            Cafes = new List<Cafe>(){
                new Cafe("Cafe 101","Los Angeles"),
                new Cafe("Cafe Jazzmatazz", "Hollywood"),
                new Cafe("Cafe Mia Belle","Austin"),
                new Cafe("Texas French Bread", "Austin"),
                new Cafe("Corner Bakery","San Francisco")
            };
        }
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}