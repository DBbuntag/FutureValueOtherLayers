using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FutureValue.Domain;
using FutureValue.Application.Interfaces;

namespace FutureValue.Persistence.Repositories
{
    public class ExecutionDetailsRepository : IExecutionDetailsRepository
    {
        readonly DatabaseContext _databaseContext;

        public ExecutionDetailsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<ExecutionDetails>> GetExecutionDetailsAsync(int id)
        {
            return await _databaseContext.ExecutionDetails
                .Where(x => x.FutureValueId == id)
                .OrderBy(x => x.Year).ToListAsync();
        }
        public async Task<ExecutionDetails> AddExecutionDetails(ExecutionDetails executionDetails)
        {
            try
            {
                _databaseContext.Add(executionDetails);
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return executionDetails;
        }
    }
}
