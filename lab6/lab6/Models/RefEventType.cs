using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class RefEventType
    {
        [Key]
        public int EventTypeCode { get; set; }
        public string EventTypeDescription { get; set; }

        public ICollection<StudentEvent> StudentEvents { get; set; }
    }
}