using System;
using System.Linq;
using System.Web.Http;
using CouponStore.Api.Models;

namespace CouponStore.Api.Controllers
{
    public class DealsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(ApiDbContext.Deals.ToList());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(ApiDbContext.Deals.First(e => e.Id == id));
                ;
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Deal deal)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            ApiDbContext.Deals.Add(deal);
            ApiDbContext.SaveChanges();
            return Ok("New Deal Added");
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Deal deal)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                Deal currentDeal;
                if ((currentDeal = ApiDbContext.Deals.First(e => e.Id == id)) != null)
                {
                    currentDeal.Title = deal.Title;
                    currentDeal.Url = deal.Url;
                    ApiDbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok($"{deal.Title} details Updated");
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
                var deal = ApiDbContext.Deals.First(e => e.Id == id);
                ApiDbContext.Deals.Remove(deal);
                ApiDbContext.SaveChanges();
                return Ok($"{deal.Title} deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}