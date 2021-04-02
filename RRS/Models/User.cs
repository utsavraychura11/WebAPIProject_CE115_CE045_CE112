using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant_rating.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string phoneno { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password {get;set;}

    }
}