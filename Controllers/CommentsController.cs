using System;
using System.Linq;
using System.Web.Http;
using CouponStore.Api.Models;

namespace CouponStore.Api.Controllers
{
    public class CommentsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(ApiDbContext.Comments.ToList());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(ApiDbContext.Comments.First(e => e.Id == id));
                ;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            ApiDbContext.Comments.Add(comment);
            ApiDbContext.SaveChanges();
            return Ok("New Comment Added");
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Comment comment)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                Comment currentComment;
                if ((currentComment = ApiDbContext.Comments.First(e => e.Id == id)) != null)
                {
                    currentComment.Identifier = comment.Identifier;
                    currentComment.IsAnonymous = comment.IsAnonymous;
                    currentComment.Title = comment.Title;
                    currentComment.Body = comment.Body;
                    ApiDbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok($"{comment.Title} details Updated");
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
                var comment = ApiDbContext.Comments.First(e => e.Id == id);
                ApiDbContext.Comments.Remove(comment);
                ApiDbContext.SaveChanges();
                return Ok($"{comment.Title} deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}