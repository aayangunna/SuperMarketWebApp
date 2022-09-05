using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Models
{
    public partial class staff
    {
        public staff()
        {
            Customers = new HashSet<Customer>();
        }
        [Key]
        public int StaffId { get; set; }
        public string StaffFirstName { get; set; } = null!;
        public string StaffLastName { get; set; } = null!;
        public string StaffAddress { get; set; } = null!;
        public string StaffPhoneNumber { get; set; } = null!;
        public string StaffStatus { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
