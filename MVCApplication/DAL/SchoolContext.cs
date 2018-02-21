using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCApplication.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace MVCApplication.DAL
{
    public class SchoolContext:DbContext
    {
        public SchoolContext() : base("SchoolContext")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
                
        //The modelBuilder.Conventions.Remove statement in the OnModelCreating method prevents table names from being pluralized
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}