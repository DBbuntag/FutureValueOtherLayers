using System.Collections.Generic;
using System.Threading.Tasks;
using FutureValue.Application.Dtos;

namespace FutureValue.Application.Interfaces
{
    public interface IExecutionDetailsQueries
    {
        Task<List<ExecutionDetailsDto>> GetExecutionDetailsAsync(int id);
    }
}
