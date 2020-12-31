using Core.Setup;
using Service.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.Setup;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        #region PROPRITY
        private IEmployeeService _employeeService;
        #endregion

        #region CONSTRUCTER
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region INDEX
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<EmployeeModel> employee = _employeeService.GetEmployees().Select(u => new EmployeeModel
            {
                Age = u.EmployeeDetails.Age,
                Email = u.EmployeeDetails.Email,
                EmployeeName = u.EmployeeName,
                LastName = u.LastName,
                ID = u.ID
            });
            return View(employee);
        }
        #endregion

        #region GET CREATE EDIT EMPLOYEE
        [HttpGet]
        public ActionResult CreateEditEmployee(int? id)
        {
            EmployeeModel model = new EmployeeModel();
            if (id.HasValue && id != 0)
            {
                Employee employeeEntity = _employeeService.GetEmployee(id.Value);
                model.Address = employeeEntity.EmployeeDetails.Address;
                model.Age = employeeEntity.EmployeeDetails.Age;
                model.Email = employeeEntity.EmployeeDetails.Email;
                model.EmployeeName = employeeEntity.EmployeeName;
                model.LastName = employeeEntity.LastName;
            }
            return View(model);
        }
        #endregion

        #region POST CREATE EDIT EMPLOYEE
        [HttpPost]
        public ActionResult CreateEditEmployee(EmployeeModel model)
        {
            if (model.ID == 0)
            {
                Employee employeeEntity = new Employee
                {
                    Department = model.Department,
                    EmployeeName = model.EmployeeName,
                    LastName = model.LastName,
                    ModifiedDate = DateTime.UtcNow,
                    AddedDate = DateTime.UtcNow,
                    EmployeeDetails = new EmployeeDetails
                    {
                        Address = model.Address,
                        Age = model.Age,
                        Email = model.Email
                    },
                };

                _employeeService.InsertEmployee(employeeEntity);
                if (employeeEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }
            }
            else
            {
                Employee employeeEntity = _employeeService.GetEmployee(model.ID);
                employeeEntity.Department = model.Department;
                employeeEntity.EmployeeName = model.EmployeeName;
                employeeEntity.LastName = model.LastName;
                employeeEntity.ModifiedDate = DateTime.UtcNow;
                employeeEntity.EmployeeDetails.Address = model.Address;
                employeeEntity.EmployeeDetails.Email = model.Email;
                employeeEntity.EmployeeDetails.Age = model.Age;
                employeeEntity.EmployeeDetails.ModifiedDate = DateTime.UtcNow;
                _employeeService.UpdateEmployee(employeeEntity);
                if (employeeEntity.ID > 0)
                {
                    return RedirectToAction("index");
                }

            }
            return View(model);
        }
        #endregion

        #region DETAILS EMPLOYEE
        public ActionResult DetailEmployee(int? id)
        {
            EmployeeModel model = new EmployeeModel();
            if (id.HasValue && id != 0)
            {
                Employee employeeEntity = _employeeService.GetEmployee(id.Value);
                // model.ID = userEntity.ID;
                model.Age = employeeEntity.EmployeeDetails.Age;
                model.Address = employeeEntity.EmployeeDetails.Address;
                model.Email = employeeEntity.EmployeeDetails.Email;
                model.EmployeeName = employeeEntity.EmployeeName;
                model.AddedDate = employeeEntity.AddedDate;
                model.LastName = employeeEntity.LastName;
                model.Department = employeeEntity.Department;
            }
            return View(model);
        }
        #endregion

        #region DELETE EMPLOYEE
        public ActionResult DeleteEmployee(int id)
        {
            EmployeeModel model = new EmployeeModel();
            if (id != 0)
            {
                Employee employeeEntity = _employeeService.GetEmployee(id);
                model.Address = employeeEntity.EmployeeDetails.Address;
                model.Age = employeeEntity.EmployeeDetails.Age;
                model.Email = employeeEntity.EmployeeDetails.Email;
                model.LastName = employeeEntity.LastName;
                model.EmployeeName = employeeEntity.EmployeeName;
                model.Department = employeeEntity.Department;
                model.AddedDate = employeeEntity.AddedDate;

            }
            return View(model);
        }
        #endregion

        #region POST DELETE EMPLOYEE
        [HttpPost]
        public ActionResult DeleteEmployee(int id, FormCollection collection)
        {
            try
            {
                if (id != 0)
                {
                    Employee employeeEntity = _employeeService.GetEmployee(id);
                    _employeeService.DeleteEmployee(employeeEntity);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        #endregion
    }
}