using System;
using System.ComponentModel.DataAnnotations;

namespace FutureValue.Domain
{
    public class FutureValues
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
