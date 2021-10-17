using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitCalculation.Contracts.Models
{
    public class FirstNameDiscountConfiguration
    {
        public string Character { get; set; }
        public decimal Percentage { get; set; }
    }
}
