using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_rating.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string phoneno { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        [JsonIgnore]
        public List<Review> review { get; set; }


    }
}