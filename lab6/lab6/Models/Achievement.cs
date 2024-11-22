using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class Achievement
    {
        [Key]
        public int AchievementId { get; set; }
        public int StudentId { get; set; }
        public int AchievementTypeCode { get; set; }
        public string AchievementDetails { get; set; }

        public Student Student { get; set; }
        public RefAchievementType RefAchievementType { get; set; }
    }
}