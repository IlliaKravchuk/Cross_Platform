using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class StudentEvent
    {
        [Key]
        public int StudentEventId { get; set; }
        public int StudentId { get; set; }
        public int EventTypeCode { get; set; }
        public string EventDetails { get; set; }

        public Student Student { get; set; }
        public RefEventType RefEventType { get; set; }
    }
}