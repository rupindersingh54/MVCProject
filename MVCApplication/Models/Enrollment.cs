using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCApplication.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [Display(Name ="Enrollment Date"),Required]
        [DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd}", ApplyFormatInEditMode =true)]
        public DateTime EnrollmentDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}