using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class RefAddressType
    {
        [Key]
        public int AddressTypeId { get; set; }
        public string AddressTypeDescription { get; set; }

        public ICollection<StudentAddress> StudentAddresses { get; set; }
    }
}