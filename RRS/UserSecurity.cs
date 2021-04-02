using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Restaurant_rating.Models;

namespace RRS
{
    public class UserSecurity
    {
        public static bool Login(string email,string pass)
        {
            DatabaseContext db = new DatabaseContext();
            User user = db.Users.Where(x => x.email == email && x.password == pass).FirstOrDefault();
            if (user != null)
                return true;
            else
                return false;
        }
    }
}