using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataTablesExercise.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("oDataStudentDb") 
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}