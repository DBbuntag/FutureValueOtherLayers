using System;

namespace FutureValue.Application.Dtos
{
    public class FutureValuesDto
    {
        public int FutureValuesId { get; set; }
        public double PresentValue { get; set; }
        public int LowerBoundInterest { get; set; }
        public int UpperBoundInterest { get; set; }
        public int IncrementalRate { get; set; }
        public int MaturityYears { get; set; }
        public DateTime ExecutionDate { get; set; }
    }
}
