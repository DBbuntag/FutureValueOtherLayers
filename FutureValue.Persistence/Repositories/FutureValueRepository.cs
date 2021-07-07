using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FutureValue.Domain;
using FutureValue.Application.Interfaces;

namespace FutureValue.Persistence.Repositories
{
    public class FutureValueRepository
        : IFutureValueRepository
    {
        readonly DatabaseContext _databaseContext;

        public FutureValueRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<FutureValues>> GetPastExecutedValuesAsync()
        {
            return await _databaseContext.FutureValues.OrderBy(x => x.ExecutionDate).ToListAsync();
        }

        public async Task<FutureValues> AddFutureValues(FutureValues futureValues)
        {
            try
            {
                _databaseContext.Add(futureValues);
                await _databaseContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return futureValues;
        }

        public async Task<FutureValues> GetFutureValueDetails(int id)
        {
            try
            {
               return await _databaseContext.FutureValues.FindAsync(id);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
