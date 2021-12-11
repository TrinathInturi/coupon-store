using System;
using System.Linq;
using System.Web.Http;
using CouponStore.Api.Models;

namespace CouponStore.Api.Controllers
{
    public class AuthorsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(ApiDbContext.Authors.ToList());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(ApiDbContext.Authors.First(e => e.Id == id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            ApiDbContext.Authors.Add(author);
            ApiDbContext.SaveChanges();
            return Ok(author);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Author author)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                Author currentAuthor;
                if ((currentAuthor = ApiDbContext.Authors.First(e => e.Id == id)) != null)
                {
                    currentAuthor.AuthorName = author.AuthorName;
                    currentAuthor.UserName = author.UserName;
                    ApiDbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok($"{author.UserName} details Updated");
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
                var author = ApiDbContext.Authors.First(e => e.Id == id);
                ApiDbContext.Authors.Remove(author);
                ApiDbContext.SaveChanges();
                return Ok($"{author.UserName} deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}