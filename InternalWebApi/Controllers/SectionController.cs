using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternalWebApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using InternalWebApi.Models;
using InternalWebApi.DTOs.Section;
using System.Net;
//using ASPNETCoreTraining.Models;

namespace InternalWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        public readonly ISectionService sectionService;

        public SectionController(ISectionService sectionService) => this.sectionService = sectionService;

        [HttpGet] // https://localhost:5001/Section
        public async Task<ActionResult<IEnumerable<SectionResponse>>> GetSectionAll()
        {
            return (await sectionService.GetAll())
                   .Select(SectionResponse.FromSection).ToList(); // Models => ModelsResponse
        }

        [HttpGet("{id}")] // https://localhost:5001/value1?
        public async Task<ActionResult<SectionResponse>> GetSectionById(int id)
        {
            var section = await sectionService.GetById(id);

            if (section == null)
            { return NotFound(); }

            return new SectionResponse {
                SectionId = section.SectionId,
                SectionName = section.SectionName,
                DepartmentName = section.Department.DepartmentName
            };
        }

        [HttpPost] // https://localhost:5001/department
        public async Task<ActionResult> AddSection ([FromForm] SectionRequest sectionRequest)
        {
            var section = new Section {
                SectionId = (int)sectionRequest.SectionId,
                SectionName = sectionRequest.SectionName,
                Description = sectionRequest.Description,
                CreateUser = sectionRequest.CreateUser,
                DepartmentId = sectionRequest.DepartmentId
            };
            await sectionService.Insert(section);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSection (int id, [FromForm] SectionRequest sectionRequest)
        {
            if (id != sectionRequest.SectionId)
            {
                return BadRequest();
            }

            var section = await sectionService.GetById(id);
            if (section == null)
            {
                return NotFound();
            }

            section.SectionName = sectionRequest.SectionName;
            await sectionService.Update(section);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSection(int id)
        {
            var section = await sectionService.GetById(id);
            if (section == null)
            {
                return NotFound();
            }

            await sectionService.Delete(section);
            return NoContent();
        }
    }
}