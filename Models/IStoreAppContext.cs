using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CouponStore.Api.Models
{
    public interface IStoreAppContext : IDisposable
    {
        DbSet<Catalogue> Catalogues { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Deal> Deals { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Guest> Guests { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Vendor> Vendors { get; set; }
        int SaveChanges();
        void MarkAsModified(Author item);
    }
}