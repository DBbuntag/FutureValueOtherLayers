using FutureValue.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureValue.Application.Interfaces
{
    public interface IExecutionDetailsCommands
    {
        Task<ExecutionDetailsDto> AddExecutionDetails(ExecutionDetailsDto executionDetails);
    }
}
