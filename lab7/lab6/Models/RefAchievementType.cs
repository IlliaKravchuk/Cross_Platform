using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class RefAchievementType
    {
        [Key]
        public int AchievementTypeCode { get; set; }
        public string AchievementTypeDescription { get; set; }

        public ICollection<Achievement> Achievements { get; set; }
    }
}