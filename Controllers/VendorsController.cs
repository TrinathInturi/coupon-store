using System;
using System.Linq;
using System.Web.Http;
using CouponStore.Api.Models;

namespace CouponStore.Api.Controllers
{
    public class VendorsController : BaseController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(ApiDbContext.Vendors.ToList());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(ApiDbContext.Vendors.First(e => e.Id == id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Vendor vendor)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            ApiDbContext.Vendors.Add(vendor);
            ApiDbContext.SaveChanges();
            return Ok("New Vendor Added");
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Vendor vendor)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                Vendor currentVendor;
                if ((currentVendor = ApiDbContext.Vendors.First(e => e.Id == id)) != null)
                {
                    currentVendor.AffiliateId = vendor.AffiliateId;
                    currentVendor.HomePageUrl = vendor.HomePageUrl;
                    currentVendor.Name = vendor.Name;
                    ApiDbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok($"{vendor.Name} details Updated");
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
                var vendor = ApiDbContext.Vendors.First(e => e.Id == id);
                ApiDbContext.Vendors.Remove(vendor);
                ApiDbContext.SaveChanges();
                return Ok($"{vendor.Name} deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}