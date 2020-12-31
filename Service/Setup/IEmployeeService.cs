using Core.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Setup
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetEmployees();
        Employee GetEmployee(long id);
        void InsertEmployee(Employee user);
        void UpdateEmployee(Employee user);
        void DeleteEmployee(Employee user);
    }
}
