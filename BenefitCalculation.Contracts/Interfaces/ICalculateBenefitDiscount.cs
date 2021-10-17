using System.Collections.Generic;

namespace BenefitCalculation.Contracts.Interfaces
{
    public interface ICalculateBenefitDiscount
    {
        void CalculateDiscount(IEmployee employee);
    }
}
