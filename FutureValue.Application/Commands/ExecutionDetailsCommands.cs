using FutureValue.Application.Dtos;
using FutureValue.Application.Interfaces;
using FutureValue.Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureValue.Application.Commands
{
    public class ExecutionDetailsCommands :IExecutionDetailsCommands
    {
        readonly Mapper _mapper;
        readonly IExecutionDetailsRepository _executionDetailsRepository;

        public ExecutionDetailsCommands(IExecutionDetailsRepository executionDetailsRepository)
        {
            _executionDetailsRepository = executionDetailsRepository;
            _mapper = new Mapper();
        }

        public async Task<ExecutionDetailsDto> AddExecutionDetails(ExecutionDetailsDto executionDetailsDto)
        {
            var mappedExecutionDetails = _mapper.MapExecutionDetailsDtoToDomain(executionDetailsDto);

            var executionDetails = await _executionDetailsRepository.AddExecutionDetails(mappedExecutionDetails);

            return _mapper.MapExecutionDetailsDomainToDto(executionDetails);
        }
    }
}
