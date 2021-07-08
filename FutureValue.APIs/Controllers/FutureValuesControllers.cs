using FutureValue.APIs.Helpers;
using FutureValue.Application.Dtos;
using FutureValue.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FutureValue.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutureValuesController : ControllerBase
    {
        readonly IFutureValueQueries _futureValueQueries;
        readonly IFutureValueCommands _futureValueCommands;

        public FutureValuesController(IFutureValueQueries futureValueQueries, IFutureValueCommands futureValueCommands)
        {
            _futureValueQueries = futureValueQueries;
            _futureValueCommands = futureValueCommands;
            ApiHelper.InitializeClient();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FutureValuesDto>>> FutureValues()
        {
            try
            {
                var futureValues = await _futureValueQueries.GetPastExecutedValues();

                return Ok(futureValues);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddFutureValues([FromBody] FutureValueModel futureValueModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                futureValueModel.FutureValuesDto = new FutureValuesDto
                {
                    PresentValue = futureValueModel.PresentValue,
                    LowerBoundInterest = futureValueModel.LowerBoundInterest,
                    UpperBoundInterest = futureValueModel.UpperBoundInterest,
                    IncrementalRate = futureValueModel.IncrementalRate,
                    MaturityYears = futureValueModel.MaturityYears
                };

                var futureValue = await _futureValueCommands.Add(futureValueModel.FutureValuesDto);
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
            var futureValueDetails = await _futureValueCommands.GetFutureValueDetails(id);
            if (futureValueDetails == null)
                return NotFound();

            return futureValueDetails;
        }
    }
}
