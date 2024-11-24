using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class RefDetentionType
    {
        [Key]
        public int DetentionTypeCode { get; set; }
        public string DetentionTypeDescription { get; set; }

        public ICollection<Detention> Detentions { get; set; }
    }
}