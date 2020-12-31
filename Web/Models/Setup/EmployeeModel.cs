using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models.Setup
{
    public class EmployeeModel
    {
        public Int64 ID { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Department { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        [Display(Name = "Added Date")]
        public DateTime AddedDate { get; set; }
    }
}