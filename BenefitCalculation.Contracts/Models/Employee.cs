using BenefitCalculation.Contracts.Interfaces;
using System.Collections.Generic;

namespace BenefitCalculation.Contracts.Models
{
    public class Employee : IEmployee
    {
        public decimal PayAmount { get; set; }
        public List<Dependent> Dependents { get; set; }
        public Benefit Benefit { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
