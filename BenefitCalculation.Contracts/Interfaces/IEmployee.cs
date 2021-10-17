using System.Collections.Generic;
using BenefitCalculation.Contracts.Models;

namespace BenefitCalculation.Contracts.Interfaces
{
    public interface IEmployee : IPerson
    {
        decimal PayAmount { get; set; }
        List<Dependent> Dependents { get; set; }
        Benefit Benefit { get; set; }
    }
}
