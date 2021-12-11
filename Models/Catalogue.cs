using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CouponStore.Api.Models
{
    public class Catalogue
    {
        [Key] public int Id { get; set; }

        public int PostId { get; set; }
        public string Title { get; set; }
        public int SubTitle { get; set; }
        public List<Deal> Deals { get; set; }
        public int Views { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")] public Author Author { get; set; }
        public int VendorId { get; set; }
        [ForeignKey("VendorId")] public Vendor Vendor { get; set; }
    }
}