using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Lab6.Data;
using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using Lab6.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new DataContext(
                   serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
        {
            if (context.Students.Any())
            {
                return;   
            }

            context.Students.AddRange(
                new Student
                {
                    BioData = "Ivan Bulk",
                    StudentDetails = "Details",
                    CreatedDate = DateTime.Now
                },
                new Student
                {
                    BioData = "Vasil Miron",
                    StudentDetails = "Details",
                    CreatedDate = DateTime.Now
                }
            );

            context.SaveChanges();
        }
    }
}