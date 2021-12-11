using System.Web.Http;
using CouponStore.Api.Context;
using CouponStore.Api.Models;

namespace CouponStore.Api.Controllers
{
    public class BaseController : ApiController
    {
        public ApiDbContext ApiDbContext = new ApiDbContext();
    }
}