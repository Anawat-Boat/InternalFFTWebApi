using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternalWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using InternalWebApi.DTOs.Department;
using InternalWebApi.Models;
using System.Net;
//using ASPNETCoreTraining.Models;

namespace InternalWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        public readonly IDepartmentService departmentService ;
        public DepartmentController(IDepartmentService departmentService) => this.departmentService = departmentService;

        [HttpGet] // https://localhost:5001/department
        public async Task<ActionResult<IEnumerable<DepartmentResponse>>> GetDepartmentAll()
        {
            return (await departmentService.GetAll())
                   .Select(DepartmentResponse.FromDepartment).ToList(); // Models => ModelsResponse
        }

        [HttpGet("{id}")] // https://localhost:5001/value1?
        public async Task<ActionResult<DepartmentResponse>> GetDepartmentById(int id)
        {
            var department = await departmentService.GetById(id);

            if (department == null)
            { return NotFound(); }

            return new DepartmentResponse {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
        }

        [HttpPost] // https://localhost:5001/department
        public async Task<ActionResult> AddDepartment ([FromForm] DepartmentRequest departmentRequest)
        {
            var department = new Department {
                DepartmentId = (int)departmentRequest.DepartmentId,
                DepartmentName = departmentRequest.DepartmentName,
                Description = departmentRequest.Description,
                CreateUser = departmentRequest.CreateUser,
            };
            await departmentService.Insert(department);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment (int id, [FromForm] DepartmentRequest departmentRequest)
        {
            if (id != departmentRequest.DepartmentId)
            {
                return BadRequest();
            }

            var department = await departmentService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            department.DepartmentName = departmentRequest.DepartmentName;
            department.LastUser = departmentRequest.CreateUser;
            await departmentService.Update(department);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var department = await departmentService.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            await departmentService.Delete(department);
            return NoContent();
        }
    }
}