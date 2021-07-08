using System.ComponentModel.DataAnnotations;

namespace FutureValue.Application.Dtos
{
    public class ExecutionDetailsDto
    {
        public int ExecutionDetailsId { get; set; }
        public int Year { get; set; }

        public double Value { get; set; }

        public double InterestRate { get; set; }
        public double FutureValue { get; set; }
        public int FutureValueId { get; set; }
    }
}
