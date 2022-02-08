using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ASPNETCoreTraining.Interfaces;
using InternalWebApi.DTOs.Position;
using InternalWebApi.Models;
using Microsoft.AspNetCore.Mvc;
//using InternalWebApi.Models;

namespace InternalWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        public readonly IPositionService positionService ;
        public PositionController(IPositionService positionService) => this.positionService = positionService;

        [HttpGet] // https://localhost:5001/position
        public async Task<ActionResult<IEnumerable<PositionResponse>>> GetPositionAll()
        {
            return (await positionService.GetAll())
                   .Select(PositionResponse.FromPosition).ToList(); // Models => ModelsResponse
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionResponse>> GetPositionById(int id)
        {
            var position = await positionService.GetById(id);

            if (position == null)
            { return NotFound(); }

            return new PositionResponse {
                PositionId = position.PositionId,
                PositionName = position.PositionName
            };
        }

        [HttpPost]
        public async Task<ActionResult<PositionResponse>> PostPosition([FromForm]PositionResponse positionRequest)
        {
            var position = new Position {
                PositionId = (int)positionRequest.PositionId,
                PositionName = positionRequest.PositionName
            };
            await positionService.Insert(position);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePosition(int id, [FromForm] PositionResponse positionRequest)
        {
            if (id != positionRequest.PositionId)
            {
                return BadRequest();
            }

            var position = await positionService.GetById(id);
            if (position == null)
            {
                return NotFound();
            }

            position.PositionName = positionRequest.PositionName;
            await positionService.Update(position);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePosition(int id)
        {
            var position = await positionService.GetById(id);
            if (position == null)
            {
                return NotFound();
            }

            await positionService.Delete(position);
            return NoContent();
        }
    }
}