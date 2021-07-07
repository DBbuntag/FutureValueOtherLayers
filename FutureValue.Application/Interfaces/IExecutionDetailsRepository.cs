using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutureValue.Domain;

namespace FutureValue.Application.Interfaces
{
    public interface IExecutionDetailsRepository
    {
        Task<List<ExecutionDetails>> GetExecutionDetailsAsync(int id);
        Task<ExecutionDetails> AddExecutionDetails(ExecutionDetails executionDetails);
    }
}
