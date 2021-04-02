using Restaurant_rating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Restaurant_rating.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    [RoutePrefix("api/restaurant")]
    public class RestaurantController : ApiController
    {
        DatabaseContext db = new DatabaseContext();

        public IEnumerable<Restaurant> getRestaurants()
        {
            return db.Restaurants.ToList();
        }

        [HttpGet]
        [Route("loadRestaurantNames")]
        public dynamic loadRestaurantNames()
        {
            var res = from Restaurants in db.Restaurants
                      select new { restaurant = Restaurants.Name };

            return res;
           
        }
        public dynamic getRestaurantById(int id)
        {
            try
            {
                Restaurant restaurant = db.Restaurants.Find(id);
                if (restaurant != null)
                {
                    return restaurant;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Restaurant With Id = " + id + "not found");

                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
            

        }

        [Route("addRestaurant")]
        [HttpPost]
        public HttpResponseMessage addRestaurant(Restaurant data)
        {
            try
            {
                db.Restaurants.Add(data);
                db.SaveChanges();
                var msg = Request.CreateResponse(HttpStatusCode.Created, data);
                msg.Headers.Location = new Uri(Request.RequestUri + data.RestaurantId.ToString());
                return msg;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

            }
        }
        [Route("updateRestaurant/{id}")]
        [HttpPut]
        public HttpResponseMessage updateRestaurant(int id, Restaurant data)
        {
            try
            {
                if (id == data.RestaurantId)
                {
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.Created);
                    return res;
                }
                else
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return res;


                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

            }
        }

        [HttpDelete]
        public HttpResponseMessage deleteRestaurant(int id)
        {
            try
            {
                Restaurant restaurant = db.Restaurants.Find(id);
                if (restaurant != null)
                {
                    db.Restaurants.Remove(restaurant);
                    db.SaveChanges();
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                    return res;

                }
                else
                {
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.NotFound);
                    return res;

                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
            


        }

    }
}
