using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutureValue.Application.Interfaces;
using FutureValue.Application.Dtos;

namespace FutureValue.Application.Queries
{
    public class ExecutionDetailsQueries :IExecutionDetailsQueries
    {
        readonly IExecutionDetailsRepository _executionDetailsRepository;
        public ExecutionDetailsQueries(IExecutionDetailsRepository executionDetailsRepository)
        {
            _executionDetailsRepository = executionDetailsRepository;
        }

        public async Task<List<ExecutionDetailsDto>> GetExecutionDetailsAsync(int id)
        {
            try
            {
                var getAll = await _executionDetailsRepository.GetExecutionDetailsAsync(id);
                var executionDetails = getAll.Select(s => new ExecutionDetailsDto
                {
                    Year = s.Year,
                    Value = s.Value,
                    InterestRate = s.InterestRate,
                    FutureValue = s.FutureValue,
                    FutureValueId = s.FutureValueId
                }).ToList();

                return executionDetails;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
