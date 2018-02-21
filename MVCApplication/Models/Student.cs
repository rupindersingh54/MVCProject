using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCApplication.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Display(Name ="First Name")]
        [Required,StringLength(50,ErrorMessage ="First Name cannot be greater than 50 characters")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required,StringLength(50, ErrorMessage = "Last Name cannot be greater than 50 characters")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^[789]\d{9}$", ErrorMessage = "Entered Mobile Number is not valid.")]
        [Display(Name = "Mobile Number")]
        public string ContactNo { get; set; }
        [StringLength(250)]
        public string Address { get; set; }
        [Display(Name="Name")]
        public string FullName { get { return FirstName + " " + LastName; } }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}