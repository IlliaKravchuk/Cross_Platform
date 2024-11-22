using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class StudentAddress
    {
        [Key]
        public int StudentAddressId { get; set; }
        public int StudentId { get; set; }
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public Student Student { get; set; }
        public Address Address { get; set; }
        public RefAddressType RefAddressType { get; set; }
    }
}