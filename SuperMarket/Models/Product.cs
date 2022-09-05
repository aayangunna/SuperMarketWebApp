using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models
{
    public partial class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer? Customer { get; set; }
    }
}
