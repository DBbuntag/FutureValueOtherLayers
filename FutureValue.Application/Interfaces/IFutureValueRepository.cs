using System.Collections.Generic;
using System.Threading.Tasks;
using FutureValue.Domain;

namespace FutureValue.Application.Interfaces
{
    public interface IFutureValueRepository
    {
        Task<List<FutureValues>> GetPastExecutedValuesAsync();
        Task<FutureValues> AddFutureValues(FutureValues futureValues);
        Task<FutureValues> GetFutureValueDetails(int id);
    }
}
