using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Restaurant_rating.Models
{
    public class DatabaseContext : DbContext
    {
            public DatabaseContext() : base("DefaultConnection")
            {
            this.Configuration.ProxyCreationEnabled = false;


            }
            public DbSet<User>Users { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Review> Reviews { get; set; }
    }
}