using System.Collections.Generic;

namespace BenefitCalculation.Contracts.Interfaces
{
    public interface ICalculateDiscountForEmployees
    {
        void CalculateEmployeeDiscount(List<IEmployee> employees);
    }
}
