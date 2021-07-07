using System.Threading.Tasks;
using FutureValue.Application.Mappers;
using FutureValue.Application.Interfaces;
using FutureValue.Application.Dtos;
using System.Collections.Generic;

namespace FutureValue.Application.Commands
{
    public class FutureValueCommands : IFutureValueCommands
    {
        readonly Mapper _mapper;
        readonly IFutureValueRepository _futureValueRepository;

        public FutureValueCommands(IFutureValueRepository futureValueRepository)
        {
            _futureValueRepository = futureValueRepository;
            _mapper = new Mapper();
        }

        public async Task<FutureValuesDto> Add(FutureValuesDto futureValuesDto)
        {
            var mappedFutureValues = _mapper.MapFutureValuesDtoToDomain(futureValuesDto);

            var futureValues = await _futureValueRepository.AddFutureValues(mappedFutureValues);

            return _mapper.MapFutureValuesDomainToDto(futureValues);
        }

        public ExecutionDetailsDto ComputeFutureValue(int id, double value, int year, int interestRate)
        {
            ExecutionDetailsDto executionDetails = new ExecutionDetailsDto
            {
                FutureValueId = id,
                Value = value,
                Year = year,
                InterestRate = interestRate,
                FutureValue = GetFutureValue(interestRate, value)
            };

            return executionDetails;
        }        

        private double GetFutureValue(double interestRate, double value)
        {
            var interestAmt = value * (interestRate / 100);
            return (value + interestAmt);
        }

        public async Task<FutureValuesDto> GetFutureValueDetails(int id)
        {
            var futureValues = await _futureValueRepository.GetFutureValueDetails(id);
            return _mapper.MapFutureValuesDomainToDto(futureValues);
        }
    }
}
