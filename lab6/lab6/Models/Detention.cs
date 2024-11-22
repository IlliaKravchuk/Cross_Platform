using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class Detention
    {
        [Key]
        public int DetentionId { get; set; }
        public int StudentId { get; set; }
        public int DetentionTypeCode { get; set; }
        public DateTime DateTimeIn { get; set; }
        public DateTime? DateTimeOut { get; set; }
        public string DetentionDetails { get; set; }

        public Student Student { get; set; }
        public RefDetentionType RefDetentionType { get; set; }
    }
}