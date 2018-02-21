using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        [StringLength(100),Required]
        [Display(Name = "Course Title")]
        public string CourseName { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
    }
}