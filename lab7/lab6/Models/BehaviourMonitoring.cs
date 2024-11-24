using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class BehaviourMonitoring
    {
        [Key]
        public int BehaviourMonitoringId { get; set; }
        public int StudentId { get; set; }
        public string MonitoringDetails { get; set; }

        public Student Student { get; set; }
    }
}