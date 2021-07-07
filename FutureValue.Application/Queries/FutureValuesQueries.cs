using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutureValue.Application.Interfaces;
using FutureValue.Application.Dtos;
using FutureValue.Application.Mappers;

namespace FutureValue.Application.Queries
{
    public class FutureValuesQueries : IFutureValueQueries
    {
        readonly IFutureValueRepository _futureValueRepo;

        public FutureValuesQueries(IFutureValueRepository futureValueRepository)
        {
            _futureValueRepo = futureValueRepository;
        }
        public async Task<List<FutureValuesDto>> GetPastExecutedValues()
        {
            try
            {
                var pastValues = await _futureValueRepo.GetPastExecutedValuesAsync();
                var all = pastValues.Select(s => new FutureValuesDto
                {
                    FutureValuesId = s.FutureValuesId,
                    PresentValue = s.PresentValue,
                    LowerBoundInterest = s.LowerBoundInterest,
                    UpperBoundInterest = s.UpperBoundInterest,
                    IncrementalRate = s.IncrementalRate,
                    MaturityYears = s.MaturityYears,
                    ExecutionDate = s.ExecutionDate
                }).ToList();

                return all;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
