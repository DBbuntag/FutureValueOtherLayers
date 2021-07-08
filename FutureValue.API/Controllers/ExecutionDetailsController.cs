using FutureValue.Application.Dtos;
using FutureValue.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FutureValue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutionDetailsController : ControllerBase
    {
        readonly IExecutionDetailsQueries _executionDetailsQueries;
        readonly IExecutionDetailsCommands _executionDetailsCommands;

        public ExecutionDetailsController(IExecutionDetailsQueries executionDetailsQueries, IExecutionDetailsCommands executionDetailsCommands)
        {
            _executionDetailsQueries = executionDetailsQueries;
            _executionDetailsCommands = executionDetailsCommands;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetExecutionDetails(int id)
        {
            var executionDetails = await _executionDetailsQueries.GetExecutionDetailsAsync(id);

            if (executionDetails.Count == 0)
                return NotFound();

            return CreatedAtAction("GetExecutionDetails", executionDetails);
        }

        [HttpPost]
        public async Task<ActionResult> AddExecutedDetails([FromBody] ExecutionDetailsDto executionDetailsDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var executionDetails = await _executionDetailsCommands.AddExecutionDetails(executionDetailsDto);
                if (executionDetails == null)
                    return BadRequest();

                return Ok(executionDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
