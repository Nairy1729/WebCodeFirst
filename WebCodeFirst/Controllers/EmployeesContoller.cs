using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebCodeFirst.Models;
using WebCodeFirst.Repositories;

namespace WebCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")] // Enable CORS for the controller
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> employees = _service.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            Employee employee = _service.GetEmployeeById(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"Employee with ID {id} not found.");
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            int result = _service.AddNewEmployee(employee);
            if (result > 0)
            {
                return Ok($"Employee with ID {result} created successfully.");
            }
            return BadRequest("Failed to create employee.");
        }

        [HttpPut]
        public IActionResult Put(Employee employee)
        {
            string result = _service.UpdateEmployee(employee);
            if (result.Contains("successfully"))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteEmployee(id);
            if (result.Contains("removed"))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
