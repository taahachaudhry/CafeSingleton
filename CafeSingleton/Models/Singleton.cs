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
        public List<Review> Reviews { get; set; }
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
            Reviews = new List<Review>(){
                new Review("Son Ngo","It's great and wonderful. Doesn't make sense it's called 101 when it's by Beltway 8.",Rating.three,0),
                new Review("Taaha Chaudhry", "Love the environment of the Hiphop Jazz and the late night LA outdoor breeze.",Rating.five,1),
                new Review("Dean Bunnell", "Such an awesome place!", Rating.four, 2),
                new Review("Paul Hume", "It's a great Cafe, I would definitely come back!", Rating.five, 3),
                new Review("Josh Yi","San Francisco's best Cafe!", Rating.five, 4),
                new Review("James Opiela", "Ponies Bro, we bronies", Rating.three, 2)
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