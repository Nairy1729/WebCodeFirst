using WebCodeFirst.Data;
using WebCodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebCodeFirst.Repositories
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MyDbContext _context;

        public EmployeeService(MyDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = _context.Employees.ToList();
            return employees.Count > 0 ? employees : null;
        }

        public Employee GetEmployeeById(int id)
        {
            if (id != 0)
            {
                var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
                return employee ?? null;
            }
            return null;
        }

        public int AddNewEmployee(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    return employee.EmployeeId;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string DeleteEmployee(int id)
        {
            if (id != 0)
            {
                var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    return "The employee with ID " + id + " was removed successfully.";
                }
                return "Employee not found.";
            }
            return "ID should not be null or zero.";
        }

        public string UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.Designation = employee.Designation;
                existingEmployee.Email = employee.Email;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.DepartmentId = employee.DepartmentId;

                _context.Entry(existingEmployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return "Employee record updated successfully.";
            }
            return "Employee not found.";
        }
    }
}
