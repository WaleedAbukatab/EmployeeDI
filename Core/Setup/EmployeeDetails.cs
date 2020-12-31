﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Setup
{
    public class EmployeeDetails : BaseEntity
    {
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
