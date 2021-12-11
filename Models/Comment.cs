namespace CouponStore.Api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public bool IsAnonymous { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}