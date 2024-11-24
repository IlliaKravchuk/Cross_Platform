using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public class StudentLoan
    {
        [Key]
        public int StudentLoanId { get; set; }
        public int StudentId { get; set; }
        public DateTime DateOfLoan { get; set; }
        public decimal AmountOfLoan { get; set; }
        public string LoanDetails { get; set; }

        public Student Student { get; set; }
    }
}