using System.ComponentModel.DataAnnotations;

namespace CouponStore.Api.Models
{
    public class Deal
    {
        [Key] public int Id { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }
    }
}