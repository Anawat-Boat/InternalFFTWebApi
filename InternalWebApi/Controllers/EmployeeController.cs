using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InternalWebApi.Models;
using ASPNETCoreTraining.Interfaces;
using InternalWebApi.DTOs.Employee;
using System.Net;

namespace InternalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService employeeService ;
        public EmployeeController(IEmployeeService employeeService) => this.employeeService = employeeService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetEmployeeAll()
        {
            return (await employeeService.GetAll())
                   .Select(EmployeeResponse.FromEmployee).ToList(); // Models => ModelsResponse
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeById(int id)
        {
            var employee = await employeeService.GetById(id);

            if (employee == null)
            { return NotFound(); }

            return new EmployeeResponse {
                EmployeeId = employee.EmployeeId,
                EmployeeCode = employee.EmployeeCode,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                SectionName = employee.Section.SectionName,
                PositionName = employee.Position.PositionName
            };
        }

        [HttpPost("")]
        public async Task<ActionResult<EmployeeResponse>> PostEmployee([FromForm]EmployeeRequest employeeRequest)
        {
            var employee = new Employee {
                EmployeeId = (int)employeeRequest.EmployeeId,
                EmployeeCode = employeeRequest.EmployeeCode,
                FirstName = employeeRequest.FirstName,
                Email = employeeRequest.Email,
                LastName = employeeRequest.LastName,
                SectionId = employeeRequest.SectionId,
                PositionId = employeeRequest.PositionId
            };
            await employeeService.Insert(employee);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, [FromForm]EmployeeRequest employeeRequest)
        {
            if (id != employeeRequest.EmployeeId)
            {
                return BadRequest();
            }

            var employee = await employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.FirstName = employeeRequest.FirstName;
            employee.LastName = employeeRequest.LastName;
            employee.Email = employeeRequest.Email;
            employee.PositionId = employeeRequest.PositionId;
            employee.SectionId = employeeRequest.SectionId;

            await employeeService.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var employee = await employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            await employeeService.Delete(employee);
            return NoContent();
        }
    }
}