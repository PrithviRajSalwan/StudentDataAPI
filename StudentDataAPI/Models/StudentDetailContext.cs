using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDataAPI.Models
{
    public class StudentDetailContext:DbContext
    {
        public StudentDetailContext(DbContextOptions<StudentDetailContext> options):base(options)
        {
              
        }


        public DbSet<StudentDetail> StudentDetail { get; set; }
    }
}
