using System.ComponentModel.DataAnnotations;

namespace CouponStore.Api.Models
{
    public class Vendor
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }
        public string HomePageUrl { get; set; }
        public string AffiliateId { get; set; }
    }
}