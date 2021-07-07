using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureValue.Domain
{
    public class ExecutionDetails
    {
        public int ExecutionDetailsId { get; set; }
        public int Year { get; set; }
        public double Value { get; set; }

        public double InterestRate { get; set; }
        public double FutureValue { get; set; }
        public FutureValues FutureValues { get; set; }
        public int FutureValueId { get; set; }
    }
}
    