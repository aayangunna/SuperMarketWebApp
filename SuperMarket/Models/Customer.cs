using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Products = new HashSet<Product>();
        }
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhoneNumber { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
        public int StaffId { get; set; }

        public virtual staff Staff { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
