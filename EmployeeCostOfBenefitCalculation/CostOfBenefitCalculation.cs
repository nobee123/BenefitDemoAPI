using BenefitCalculation.Contracts.Interfaces;
using BenefitCalculation.Contracts.Models;

namespace EmployeeCostOfBenefitCalculation
{
    public class CostOfBenefitCalculation : ICalculateBenefit
    {
        private decimal _costOfBenefit;
        public CostOfBenefitCalculation(decimal costOfBenefit)
        {
            _costOfBenefit = costOfBenefit;
        }
        public void CalculateBenefit(IEmployee employee)
        {
            if (employee.Benefit == null)
            {
                employee.Benefit = new Benefit();
            }
            employee.Benefit.CostOfBenefitEmployee = _costOfBenefit;
        }
    }
}
