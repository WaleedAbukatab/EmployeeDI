using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Setup
{
    public class Employee : BaseEntity
    {
        public string EmployeeName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public virtual EmployeeDetails EmployeeDetails { get; set; }
    }
}
