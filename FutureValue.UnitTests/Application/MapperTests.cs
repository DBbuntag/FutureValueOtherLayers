using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutureValue.Application.Dtos;
using FutureValue.Application.Mappers;
using FutureValue.Domain;
using FutureValue.UnitTests.Shared;
using NUnit.Framework;

namespace FutureValue.UnitTests.Application
{
    public class MapperTests
    {
        private FutureValues _futureValues;
        private FutureValuesDto _futureValuesDto;
        private ExecutionDetails _executionDetails;
        private ExecutionDetailsDto _executionDetailsDto;
        readonly Mapper _mapper;
        public MapperTests()
        {
            _mapper = new Mapper();
        }

        [Test]
        public void MapFutureValuesDtoToDomain()
        {
            _futureValuesDto = new FutureValuesDto
            {
                FutureValuesId = MapperConstants.FutureValueProps.futureValuesId,
                PresentValue = MapperConstants.FutureValueProps.presentValue,
                LowerBoundInterest = MapperConstants.FutureValueProps.lowerBoundInterest,
                UpperBoundInterest = MapperConstants.FutureValueProps.upperBoundInterest,
                IncrementalRate = MapperConstants.FutureValueProps.incrementalRate,
                MaturityYears = MapperConstants.FutureValueProps.maturityYears,
                ExecutionDate = DateTime.Now
            };

            var result = _mapper.MapFutureValuesDtoToDomain(_futureValuesDto);

            Assert.IsNotNull(result);
        }

        [Test]
        public void MapFutureValuesDomainToDto()
        {
            _futureValues = new FutureValues
            {
                FutureValuesId = MapperConstants.FutureValueProps.futureValuesId,
                PresentValue = MapperConstants.FutureValueProps.presentValue,
                LowerBoundInterest = MapperConstants.FutureValueProps.lowerBoundInterest,
                UpperBoundInterest = MapperConstants.FutureValueProps.upperBoundInterest,
                IncrementalRate = MapperConstants.FutureValueProps.incrementalRate,
                MaturityYears = MapperConstants.FutureValueProps.maturityYears,
                ExecutionDate = DateTime.Now
            };

            var result = _mapper.MapFutureValuesDomainToDto(_futureValues);

            Assert.IsNotNull(result);
        }

        [Test]
        public void MapExecutionDetailsDtoToDomain()
        {
            _executionDetailsDto = new ExecutionDetailsDto
            {
                FutureValueId = MapperConstants.ExecutionDetailsProps.futureValueId,
                Year = MapperConstants.ExecutionDetailsProps.year,
                Value = MapperConstants.ExecutionDetailsProps.value,
                InterestRate = MapperConstants.ExecutionDetailsProps.interestRate,
                FutureValue = MapperConstants.ExecutionDetailsProps.futureValue
            };

            var result = _mapper.MapExecutionDetailsDtoToDomain(_executionDetailsDto);

            Assert.IsNotNull(result);
        }

        [Test]
        public void MapExecutionDetailsDomainToDto()
        {
            _executionDetails = new ExecutionDetails
            {
                FutureValueId = MapperConstants.ExecutionDetailsProps.futureValueId,
                Year = MapperConstants.ExecutionDetailsProps.year,
                Value = MapperConstants.ExecutionDetailsProps.value,
                InterestRate = MapperConstants.ExecutionDetailsProps.interestRate,
                FutureValue = MapperConstants.ExecutionDetailsProps.futureValue
            };

            var result = _mapper.MapExecutionDetailsDomainToDto(_executionDetails);

            Assert.IsNotNull(result);
        }
    }
}
