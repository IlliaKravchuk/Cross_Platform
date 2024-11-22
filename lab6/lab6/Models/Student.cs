using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string BioData { get; set; }
        public string StudentDetails { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<StudentAddress> StudentAddresses { get; set; }
        public ICollection<StudentEvent> StudentEvents { get; set; }
        public ICollection<StudentLoan> StudentLoans { get; set; }
        public ICollection<Transcript> Transcripts { get; set; }
        public ICollection<BehaviourMonitoring> BehaviourMonitorings { get; set; }
        public ICollection<Detention> Detentions { get; set; }
    }
}