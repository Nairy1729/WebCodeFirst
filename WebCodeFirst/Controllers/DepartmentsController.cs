﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCodeFirst.Models;
using WebCodeFirst.Repositories;

namespace WebCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")] // Enable CORS for this controller using the "AllowAll" policy
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;
        public DepartmentsController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> departments = _service.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            Department department = _service.GetDepartmentById(id);
            return Ok(department);
        }

        [HttpPost]
        public IActionResult Post(Department department)
        {
            int Result = _service.AddNewDepartment(department);
            return Ok(Result);
        }

        [HttpPut]
        public IActionResult Put(Department department)
        {
            string result = _service.UpdateDepartment(department);
            return Ok(result);
        }

        [HttpDelete("{id}")] // Specify that this route expects an ID in the URL
        public IActionResult Delete(int id)
        {
            string result = _service.DeleteDepartment(id);
            return Ok(result);
        }
    }
}
