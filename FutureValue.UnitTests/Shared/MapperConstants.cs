using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureValue.UnitTests.Shared
{
    public class MapperConstants
    {
        public class FutureValueProps
        {
            public const int futureValuesId = 1;
            public const double presentValue = 1000;
            public const int lowerBoundInterest = 10;
            public const int upperBoundInterest = 50;
            public const int incrementalRate = 10;
            public const int maturityYears = 4;
        }

        public class ExecutionDetailsProps
        {
            public const int futureValueId = 1;
            public const int year = 1;
            public const double value = 1000;
            public const int interestRate = 10;
            public const int futureValue = 1100;
        }
    }
}
