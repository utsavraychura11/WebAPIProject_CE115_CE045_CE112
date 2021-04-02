using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant_rating.Models
{
    public class Review
    {

        public int ReviewId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }


        [ForeignKey("Restaurant")]
        public int RestaurantId  { get; set; }
        [JsonIgnore]
        public virtual Restaurant Restaurant { get; set; }

        public int cleanliness_rating { get; set; }
        public int staff_rating { get; set; }
        public int food_rating { get; set; }
        public string review_detail { get; set; }

    }
}