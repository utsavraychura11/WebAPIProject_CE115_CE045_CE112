using Restaurant_rating.Models;
using RRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Restaurant_rating.Controllers
{
    //[Authorize]
    [EnableCorsAttribute("*","*","*")]
   // [RoutePrefix("user")]
    public class UserController : ApiController
    {
        /*[HttpGet]
        public string Hello(string name)
        {
            return "Hello" + name;
        }*/

        DatabaseContext db = new DatabaseContext();

        //[BasicAuthentication]
        public IEnumerable<User> GetUsers()
        {
            //string email = Thread.CurrentPrincipal.Identity.Name;
            return db.Users.ToList();
        }
        public dynamic GetUserById(int id)
        {
            try
            {
                User user = db.Users.Find(id);
                if (user != null)
                {

                    return user;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User With Id = " + id + "not found");
                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddUser(User data)
        {
            try
            {
                db.Users.Add(data);
                db.SaveChanges();
                // HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.Created);
                var msg = Request.CreateResponse(HttpStatusCode.Created, data);
                msg.Headers.Location = new Uri(Request.RequestUri + data.UserId.ToString());
                return msg;
                //return res;
            }
            catch(Exception e)
            {

                Console.WriteLine(e);
                // HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

            }
        }
        [HttpPut]
        //[Route("updateUser/{id}")]
        public HttpResponseMessage UpdateUser(int id, User data)
        {
            try
            {
                if (id == data.UserId)
                {
                    db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.Created);
                    return res;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User With Id = " + id + "not found");


                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);

            }
        }
            
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                User user = db.Users.Find(id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                    HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                    return res;

                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User With Id = " + id + "not found");

                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }

         
    
    }
}
