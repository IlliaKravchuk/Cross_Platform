using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public string ClassDetails { get; set; }

        public Teacher Teacher { get; set; }
    }
}