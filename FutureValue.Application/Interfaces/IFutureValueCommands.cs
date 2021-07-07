using FutureValue.Application.Dtos;
using System.Threading.Tasks;

namespace FutureValue.Application.Interfaces
{
    public interface IFutureValueCommands
    {
        Task<FutureValuesDto> Add(FutureValuesDto futureValuesDto);
        ExecutionDetailsDto ComputeFutureValue(int id, double value, int year, int interestRate);
        Task<FutureValuesDto> GetFutureValueDetails(int id);
    }
}
