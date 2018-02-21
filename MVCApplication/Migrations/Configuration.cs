namespace MVCApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVCApplication.Models;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<MVCApplication.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVCApplication.DAL.SchoolContext";
        }

        protected override void Seed(MVCApplication.DAL.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Student Data
            var students = new List<Student>
            {
                new Student { FirstName = "Rupinder", LastName = "Singh",
                ContactNo = "8974561322",Address="Amritsar" },
                new Student { FirstName = "John", LastName = "Adams",
                ContactNo = "9851561552",Address="Amritsar" },
                new Student { FirstName = "Arturo", LastName = "Anand",
                ContactNo = "9152452253",Address="Amritsar" },
                new Student { FirstName = "Gytis", LastName = "Barzdukas",
                ContactNo = "9854561452",Address="Amritsar"},
                new Student { FirstName = "Yan", LastName = "Li",
                ContactNo = "9547512362",Address="Amritsar" },
                new Student { FirstName = "Peggy", LastName = "Justice",
                ContactNo = "9876543210",Address="Amritsar" },
                new Student { FirstName = "Laura", LastName = "Norman",
                ContactNo = "8745962145",Address="Amritsar" },
                new Student { FirstName = "Nino", LastName = "Olivetto",
                ContactNo = "9654125462",Address="Amritsar" }
            };
            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();

            //DEPARTMENT DATA


            var department = new List<Department>
            {
                new Department { Name= "Programming Languages",Owner="Direct Axis"},
                new Department { Name= "Designing",Owner="Direct Axis"},
                new Department { Name= "Accounts",Owner="Direct Axis"}

            };
            department.ForEach(s => context.Departments.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
            //Course Data
            var courses = new List<Course>
            {
                new Course {CourseName= "C#.Net",DepartmentID = department.Single(c => c.Name== "Programming Languages" ).DepartmentID},
                new Course {CourseName= "VB.Net",DepartmentID = department.Single(c => c.Name== "Programming Languages" ).DepartmentID},
                new Course {CourseName= "MVC",DepartmentID = department.Single(c => c.Name== "Programming Languages" ).DepartmentID},
                new Course {CourseName= "Java",DepartmentID = department.Single(c => c.Name== "Programming Languages" ).DepartmentID},
                new Course {CourseName= "HTML",DepartmentID = department.Single(c => c.Name== "Designing" ).DepartmentID},
                new Course {CourseName= "BootStrap",DepartmentID = department.Single(c => c.Name== "Designing" ).DepartmentID},
                new Course {CourseName= "Accounting",DepartmentID = department.Single(c => c.Name== "Accounts" ).DepartmentID},

            };
            courses.ForEach(s => context.Courses.AddOrUpdate(p => p.CourseName, s));
            context.SaveChanges();
            // Enrollment Data
            var enrollments = new List<Enrollment>
            {
                new Enrollment {CourseID=courses.Single(e=>e.CourseName=="C#.Net").CourseID,
                StudentID=students.Single(e=>e.FirstName=="Rupinder" && e.LastName=="Singh").StudentID,
                EnrollmentDate=DateTime.Parse("2012-11-19")},
                new Enrollment {CourseID=courses.Single(e=>e.CourseName=="MVC").CourseID,
                StudentID=students.Single(e=>e.FirstName=="Rupinder" && e.LastName=="Singh").StudentID,
                EnrollmentDate=DateTime.Parse("2018-02-15")},
                new Enrollment {CourseID=courses.Single(e=>e.CourseName=="HTML").CourseID,
                StudentID=students.Single(e=>e.FirstName=="Rupinder" && e.LastName=="Singh").StudentID,
                EnrollmentDate=DateTime.Parse("2013-03-16")},
                new Enrollment {CourseID=courses.Single(e=>e.CourseName=="C#.Net").CourseID,
                StudentID=students.Single(e=>e.FirstName=="John" && e.LastName=="Adams").StudentID,
                EnrollmentDate=DateTime.Parse("2017-02-25")},
                new Enrollment {CourseID=courses.Single(e=>e.CourseName=="MVC").CourseID,
                StudentID=students.Single(e=>e.FirstName=="Arturo" && e.LastName=="Anand").StudentID,
                EnrollmentDate=DateTime.Parse("2008-09-13")},
                new Enrollment {CourseID=courses.Single(e=>e.CourseName=="HTML").CourseID,
                StudentID=students.Single(e=>e.FirstName=="Nino" && e.LastName=="Olivetto").StudentID,
                EnrollmentDate=DateTime.Parse("2016-10-21")},
                new Enrollment {CourseID=courses.Single(e=>e.CourseName=="Accounting").CourseID,
                StudentID=students.Single(e=>e.FirstName=="Gytis" && e.LastName=="Barzdukas").StudentID,
                EnrollmentDate=DateTime.Parse("2015-07-20")},
                new Enrollment {CourseID=courses.Single(e=>e.CourseName=="HTML").CourseID,
                StudentID=students.Single(e=>e.FirstName=="Peggy" && e.LastName=="Justice").StudentID,
                EnrollmentDate=DateTime.Parse("2014-05-14")},
                new Enrollment {CourseID=courses.Single(e=>e.CourseName=="MVC").CourseID,
                StudentID=students.Single(e=>e.FirstName=="Yan" && e.LastName=="Li").StudentID,
                EnrollmentDate=DateTime.Parse("2016-11-25")}

            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                s => s.Student.StudentID == e.StudentID &&
                s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
