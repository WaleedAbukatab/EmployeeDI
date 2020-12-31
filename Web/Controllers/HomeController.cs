using Service.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeService employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
    }
}