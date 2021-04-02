using Restaurant_rating.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Restaurant_rating.Controllers
{
    [EnableCorsAttribute("*", "*", "*")]
    [RoutePrefix("api/review") ]
    public class ReviewController : ApiController
    {
      
        DatabaseContext db = new DatabaseContext();



        [Route("")]
        public IEnumerable<Review> GetReviews()
        {
           db.Configuration.ProxyCreationEnabled = false;

            return db.Reviews.ToList();
        }
        [Route("{id}")]
        public dynamic GetReviewById(int id)
        {
           db.Configuration.ProxyCreationEnabled = false;

            Review review = db.Reviews.Find(id);
            if (review != null)
            {

                return review;
            }
            else
            {
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.NotFound);
                return res;

            }

        }

        [HttpPost]
        [Route("addreview")]

        public async System.Threading.Tasks.Task<HttpResponseMessage> AddReview(Review data)
        {
            try
            {

                var restaurant =await db.Restaurants.FindAsync(data.RestaurantId);
                var user = await db.Users.FindAsync(data.UserId);
                data.Restaurant = restaurant;
                data.User = user;
                db.Reviews.Add(data);
                restaurant.review.Add(data);
                              
                db.SaveChanges();
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.Created);
                return res;
            }
            catch (Exception e)
            {
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return res;

            }
        }
        [HttpPut]
        [Route("updatereview/{id}")]
        public HttpResponseMessage UpdateReview(int id, Review data)
        {
      //      db.Configuration.ProxyCreationEnabled = false;

            try
            {
                if (id == data.ReviewId)
                {
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
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
                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return res;

            }
        }

        [Route("delete/{id}")]
        public HttpResponseMessage DeleteReview(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review != null)
            {
                db.Reviews.Remove(review);
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

        [Route("getreviewsbyuserid/{id}")]
        public async System.Threading.Tasks.Task<dynamic> GetByUserId(int id)
       {
            db.Configuration.ProxyCreationEnabled = false;
            id = 1;
            // User user = await db.Users.FindAsync(id);
            // var res =  await db.Reviews.Where(r => r.UserId == id).ToListAsync();
            var res = db.Restaurants.Join(db.Reviews.Where(u => u.UserId == id),
                restaurant => restaurant.RestaurantId,
                review => review.RestaurantId,
                  (restaurant, review) => new {
                      food_rating = review.food_rating,
                      review_detail = review.review_detail,
                      restaurantname = restaurant.Name,
                      staff_rating = review.staff_rating,
                      cleanliness_rating = review.cleanliness_rating

                  }
                ); 
            return res;
       }

        [Route("getreviewsbyrestaurantid/{id}")]
        public async System.Threading.Tasks.Task<dynamic> GetByRestaurantId(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var res = db.Users.Join(db.Reviews.Where(u => u.RestaurantId == id),
               user => user.UserId,
                review => review.UserId,
               (user,review) => new { User = user, Review = review }
               );
            return res;

        }
        [Route("getallreviews")]
        public async System.Threading.Tasks.Task<dynamic> GetAllReviews()
        {


            var res = from u in db.Users
                      join r in db.Reviews on u.UserId equals r.UserId
                      join rest in db.Restaurants on r.RestaurantId equals rest.RestaurantId
                      select new
                      {

                          ReviewId = r.ReviewId,
                          food_rating = r.food_rating,
                          Username = u.Name,
                          review_detail = r.review_detail,
                          restaurantname = rest.Name,
                          staff_rating = r.staff_rating,
                          cleanliness_rating = r.cleanliness_rating
                      };


            return res;


            return res;

        }

        [Route("deletereview/{id}")]
        [HttpDelete]
        public HttpResponseMessage deletReview(int id)
        {
            try
            {
                Review review = db.Reviews.Find(id);
                if (review != null)
                {
                    db.Reviews.Remove(review);
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

        [Route("GetReviews")]
        public IEnumerable<Review> getReviews()
        {
            return db.Reviews.ToList();
        }

        [HttpPost]
        [Route("login")]
        
        public HttpResponseMessage Login(User data)
        {
            try
            {

                User user = db.Users.Where(x => x.email == data.email).FirstOrDefault();
                if (user != null)
                {
                    if (user.password == data.password)
                    {
                        HttpResponseMessage res1 = new HttpResponseMessage(HttpStatusCode.Found);
                        return res1;
                    }
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.NotFound);
                    return res;

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User With provided email & password not found");

                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }


        }

    }


}
