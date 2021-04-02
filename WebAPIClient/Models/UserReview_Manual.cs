using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIClient.Models
{
    public class UserReview_Manual
    {
        // public int UserId { get; set; }
        public string ReviewId { get; set; }
        public string restaurantname { get; set; }
        public int cleanliness_rating { get; set; }
        public int food_rating { get; set; }
        public int staff_rating { get; set; }
        public string review_detail { get; set; }
    }
}