using System;
using System.Linq;
using System.Web.Http;
using CouponStore.Api.Models;

namespace CouponStore.Api.Controllers
{
    public class CataloguesController : BaseController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(ApiDbContext.Catalogues.ToList());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(ApiDbContext.Catalogues.First(e => e.Id == id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Catalogue catalogue)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            ApiDbContext.Catalogues.Add(catalogue);
            ApiDbContext.SaveChanges();
            return Ok("New Catalogue Added");
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Catalogue catalogue)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");
                Catalogue currentCatalogue;
                if ((currentCatalogue = ApiDbContext.Catalogues.First(e => e.Id == id)) != null)
                {
                    currentCatalogue.PostId = catalogue.PostId;
                    currentCatalogue.Title = catalogue.Title;
                    currentCatalogue.SubTitle = catalogue.SubTitle;
                    currentCatalogue.Deals = catalogue.Deals;
                    currentCatalogue.Views = catalogue.Views;
                    currentCatalogue.CreatedOn = catalogue.CreatedOn;
                    currentCatalogue.LastModifiedOn = catalogue.LastModifiedOn;
                    currentCatalogue.AuthorId = catalogue.AuthorId;
                    ApiDbContext.SaveChanges();
                }
                else
                {
                    return NotFound();
                }

                return Ok($"{catalogue.Title} Updated");
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
                var catalogue = ApiDbContext.Catalogues.First(e => e.Id == id);
                ApiDbContext.Catalogues.Remove(catalogue);
                ApiDbContext.SaveChanges();
                return Ok($"{catalogue.Title} deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}