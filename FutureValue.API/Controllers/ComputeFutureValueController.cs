using FutureValue.API.Helper;
using FutureValue.Application.Dtos;
using FutureValue.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ComputeFutureValueController : ControllerBase
    {
        readonly IFutureValueCommands _futureValueCommands;
        private ExecutionDetailsDto _executionDetailsDto = new ExecutionDetailsDto();

        public ComputeFutureValueController(IFutureValueCommands futureValueCommands)
        {
            _futureValueCommands = futureValueCommands;
            ApiHelper.InitializeClient();
        }

        [HttpPost()]
        public async Task GetComputedFutureValue(FutureValuesDto futureValuesDto)
        {
            int i = 0, interestRate = futureValuesDto.LowerBoundInterest;
            double value = futureValuesDto.PresentValue;

            while ((i + 1) <= futureValuesDto.MaturityYears)
            {
                interestRate = GetInterestRate(i, interestRate, futureValuesDto.IncrementalRate, futureValuesDto.UpperBoundInterest);
                _executionDetailsDto = _futureValueCommands.ComputeFutureValue(futureValuesDto.FutureValuesId, value, i, interestRate);
                if (_executionDetailsDto != null)
                {
                    using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync("api/ExecutionDetails", _executionDetailsDto))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            Uri cUrl = response.Headers.Location;
                            //set value to latest futureValue from the computedValue
                            value = _executionDetailsDto.FutureValue;
                        }
                    }
                }
                i++;
            }
        }

        private int GetInterestRate(int year, int interestRate, int incrementalRate, int upperBoundInterest)
        {
            if (interestRate <= upperBoundInterest)
                interestRate = (year == 0 ? interestRate : (interestRate + incrementalRate));
            else
                interestRate = upperBoundInterest;

            return interestRate;
        }
    }
}
