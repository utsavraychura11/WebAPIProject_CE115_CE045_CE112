using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIClient.Models
{
    public class Review_Manual
    {
        public int ReviewId { get; set; }
        public string Username { get; set; }
        public string restaurantname { get; set; }
        public int food_rating { get; set; } 
        public int staff_rating { get; set; }
        public int cleanliness_rating { get; set; }
        public string review_detail { get; set; }
    }
}