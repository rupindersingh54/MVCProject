using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCApplication.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Display(Name = "Department Name")]
        [StringLength(50,ErrorMessage ="Department Name cannot be greater than 50 characters."),Required]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "Owner Name cannot be greater than 50 characters.")]
        public string Owner { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}