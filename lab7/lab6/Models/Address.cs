using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string AddressDetails { get; set; }

        public ICollection<StudentAddress> StudentAddresses { get; set; }
    }
}