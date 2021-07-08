using System;
using System.ComponentModel.DataAnnotations;

namespace FutureValue.Application.Dtos
{
    public class FutureValuesDto
    {
        public int FutureValuesId { get; set; }
        public double PresentValue { get; set; }
        [Range(1, 100, ErrorMessage = "Your value must be between {0} and {1}")]
        public int LowerBoundInterest { get; set; }
        [Range(1, 100, ErrorMessage = "Your value must be between {0} and {1}")]
        public int UpperBoundInterest { get; set; }
        [Range(1, 100, ErrorMessage = "Your value must be between {0} and {1}")]
        public int IncrementalRate { get; set; }
        public int MaturityYears { get; set; }
        public DateTime ExecutionDate { get; set; }
    }
}
