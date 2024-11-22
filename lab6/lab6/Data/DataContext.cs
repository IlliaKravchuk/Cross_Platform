using Lab6.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Emit;
using System.Web;

namespace Lab6.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<StudentEvent> StudentEvents { get; set; }
        public DbSet<StudentLoan> StudentLoans { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }
        public DbSet<BehaviourMonitoring> BehaviourMonitorings { get; set; }
        public DbSet<Detention> Detentions { get; set; }
        public DbSet<RefEventType> RefEventTypes { get; set; }
        public DbSet<RefAchievementType> RefAchievementTypes { get; set; }
        public DbSet<RefDetentionType> RefDetentionTypes { get; set; }
        public DbSet<RefAddressType> RefAddressTypes { get; set; }

    }
}