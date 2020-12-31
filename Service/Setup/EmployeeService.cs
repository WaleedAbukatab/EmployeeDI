using Core.Setup;
using Data.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Setup
{
    public class EmployeeService : IEmployeeService
    {
        #region VARIABLES
        private IRepository<Employee> employeeRepository;
        private IRepository<EmployeeDetails> employeeDetailsRepository;
        #endregion CONSTRUCTOR

        #region CONSTRUCTOR
        public EmployeeService(IRepository<Employee> employeeRepository, IRepository<EmployeeDetails> employeeDetailsRepository)
        {
            this.employeeRepository = employeeRepository;
            this.employeeDetailsRepository = employeeDetailsRepository;
        }
        #endregion

        #region GET EMPLOYEE
        public IQueryable<Employee> GetEmployees()
        {
            return employeeRepository.Table;
        }
        #endregion

        #region GET EMPLOYEE BY ID
        public Employee GetEmployee(long id)
        {
            return employeeRepository.GetById(id);
        }
        #endregion

        #region INSERT EMPLOYEE
        public void InsertEmployee(Employee employee)
        {
            employeeRepository.Insert(employee);
        }
        #endregion

        #region UPDATE EMPLOYEE
        public void UpdateEmployee(Employee employee)
        {
            employeeRepository.Update(employee);
        }
        #endregion

        #region DELETE EMPLOYEE
        public void DeleteEmployee(Employee employee)
        {
            employeeDetailsRepository.Delete(employee.EmployeeDetails);
            employeeRepository.Delete(employee);
        }
        #endregion
    }
}
