using WebCodeFirst.Models;
using System.Collections.Generic;

namespace WebCodeFirst.Repositories
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        int AddNewEmployee(Employee employee);
        string DeleteEmployee(int id);
        string UpdateEmployee(Employee employee);
    }
}
