using System.Collections.Generic;
using System.Threading.Tasks;
using FutureValue.Application.Dtos;

namespace FutureValue.Application.Interfaces
{
    public interface IFutureValueQueries
    {
        Task<List<FutureValuesDto>> GetPastExecutedValues();
    }
}
