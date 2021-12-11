using System.ComponentModel.DataAnnotations;

namespace CouponStore.Api.Models
{
    public class Author
    {
        [Key] public int Id { get; set; }

        public string AuthorName { get; set; }
        public string UserName { get; set; }
    }
}