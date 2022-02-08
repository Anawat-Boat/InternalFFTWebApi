using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCoreTraining.Interfaces;
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
        public async Task<ActionResult<IEnumerable<Position>>> GetTModels()
        {
            // TODO: Your code here
            await Task.Yield();

            return new List<TModel> { };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TModel>> GetTModelById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPost("")]
        public async Task<ActionResult<TModel>> PostTModel(TModel model)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTModel(int id, TModel model)
        {
            // TODO: Your code here
            await Task.Yield();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TModel>> DeleteTModelById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }
    }
}