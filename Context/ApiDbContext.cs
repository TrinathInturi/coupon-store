using System.Data.Entity;
using CouponStore.Api.Models;

namespace CouponStore.Api.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext() : base("SmartBuyerBay")
        {
        }

        public DbSet<Catalogue> Catalogues { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}