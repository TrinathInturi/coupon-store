using System;
using System.Linq;
using System.Web.Http;
using CouponStore.Api.Models;

namespace CouponStore.Api.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(ApiDbContext.Users.ToList());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(ApiDbContext.Users.First(e => e.Id == id));
                ;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            ApiDbContext.Users.Add(user);
            ApiDbContext.SaveChanges();
            return Ok("New User Added");
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                User currentUser;
                if ((currentUser = ApiDbContext.Users.First(e => e.Id == id)) != null)
                {
                    currentUser.FullName = user.FullName;
                    currentUser.UserName = user.UserName;
                    currentUser.Age = user.Age;
                    currentUser.Phone = user.Phone;
                    currentUser.Email = user.Email;
                    currentUser.City = user.City;
                    currentUser.Country = user.Country;
                    ApiDbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok($"{user.UserName} details Updated");
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var user = ApiDbContext.Users.First(e => e.Id == id);
                ApiDbContext.Users.Remove(user);
                ApiDbContext.SaveChanges();
                return Ok($"{user.UserName} deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}