using FutureValue.API.Helper;
using FutureValue.API.Model;
using FutureValue.Application.Dtos;
using FutureValue.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FutureValue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutureValuesController : ControllerBase
    {
        readonly IFutureValueQueries _futureValueQueries;
        readonly IFutureValueCommands _futureValueCommands;
        private readonly ApplicationSettings _applicationSettings;

        public FutureValuesController(IFutureValueQueries futureValueQueries, IFutureValueCommands futureValueCommands, IOptions<ApplicationSettings> appSettings)
        {
            _futureValueQueries = futureValueQueries;
            _futureValueCommands = futureValueCommands;
            _applicationSettings = appSettings.Value;
            ApiHelper.InitializeClient(_applicationSettings.API_URL);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FutureValuesDto>), 200)]
        public async Task<ActionResult<IEnumerable<FutureValuesDto>>> FutureValues()
        {
            try
            {
                var futureValues = await _futureValueQueries.GetPastExecutedValues();
                if (futureValues != null)
                    return Ok(futureValues);
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddFutureValues([FromBody] FutureValuesDto futureValuesDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var futureValue = await _futureValueCommands.Add(futureValuesDto);
                if (futureValue == null)
                    return BadRequest();
                else
                {
                    using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync("api/ComputeFutureValue", futureValue))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            Uri cUrl = response.Headers.Location;
                        }
                    }
                }

                return CreatedAtAction("FutureValues", new { id = futureValue.FutureValuesId }, futureValue);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FutureValuesDto>> FutureValues(int id)
        {
            try
            {
                var futureValueDetails = await _futureValueCommands.GetFutureValueDetails(id);
                if (futureValueDetails == null)
                    return NotFound();

                return futureValueDetails;
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
