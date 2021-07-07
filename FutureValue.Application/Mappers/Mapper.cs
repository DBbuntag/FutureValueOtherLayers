using FutureValue.Application.Dtos;
using FutureValue.Domain;

namespace FutureValue.Application.Mappers
{
    public class Mapper
    {
        #region FutureValuesMappers
        public FutureValues MapFutureValuesDtoToDomain(FutureValuesDto futureValuesDto)
        {
            return new FutureValues
            {
                FutureValuesId = futureValuesDto.FutureValuesId,
                PresentValue = futureValuesDto.PresentValue,
                LowerBoundInterest = futureValuesDto.LowerBoundInterest,
                UpperBoundInterest = futureValuesDto.UpperBoundInterest,
                IncrementalRate = futureValuesDto.IncrementalRate,
                MaturityYears = futureValuesDto.MaturityYears,
                ExecutionDate = futureValuesDto.ExecutionDate
            };
        }

        public FutureValuesDto MapFutureValuesDomainToDto(FutureValues futureValues)
        {
            return new FutureValuesDto
            {
                FutureValuesId = futureValues.FutureValuesId,
                PresentValue = futureValues.PresentValue,
                LowerBoundInterest = futureValues.LowerBoundInterest,
                UpperBoundInterest = futureValues.UpperBoundInterest,
                IncrementalRate = futureValues.IncrementalRate,
                MaturityYears = futureValues.MaturityYears,
                ExecutionDate = futureValues.ExecutionDate
            };
        }
        #endregion

        #region ExecutionDetailsMappers
        public ExecutionDetails MapExecutionDetailsDtoToDomain(ExecutionDetailsDto executionDetailsDto)
        {
            return new ExecutionDetails
            {
                FutureValueId = executionDetailsDto.FutureValueId,
                Year = executionDetailsDto.Year,
                Value = executionDetailsDto.Value,
                InterestRate = executionDetailsDto.InterestRate,
                FutureValue = executionDetailsDto.FutureValue
            };
        }

        public ExecutionDetailsDto MapExecutionDetailsDomainToDto(ExecutionDetails executionDetails)
        {
            return new ExecutionDetailsDto
            {
                FutureValueId = executionDetails.FutureValueId,
                Year = executionDetails.Year,
                Value = executionDetails.Value,
                InterestRate = executionDetails.InterestRate,
                FutureValue = executionDetails.FutureValue
            };
        }
        #endregion
    }
}
