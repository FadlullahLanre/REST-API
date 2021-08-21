using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_Tutorial.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIs_Tutorial.Data
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options):base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<ExamDetail> ExamDetails { get; set; }
        public DbSet<Results> Results { get; set; }


    }
}
