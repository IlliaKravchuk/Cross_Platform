using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class Transcript
    {
        [Key]
        public int TranscriptId { get; set; }
        public int StudentId { get; set; }
        public DateTime DateOfTranscript { get; set; }
        public string TranscriptDetails { get; set; }

        public Student Student { get; set; }
    }
}