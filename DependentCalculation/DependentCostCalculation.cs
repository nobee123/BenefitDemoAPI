using BenefitCalculation.Contracts.Interfaces;
using BenefitCalculation.Contracts.Models;

namespace DependentCalculation
{
    public class DependentCostCalculation : ICalculateBenefit
    {
        private decimal _costOfBenefit;
        public DependentCostCalculation(decimal costOfBenefit)
        {
            _costOfBenefit = costOfBenefit;
        }
        public void CalculateBenefit(IEmployee employee)
        {
            if(employee.Dependents == null)
            {
                return;
            }
            if (employee.Benefit == null)
            {
                employee.Benefit = new Benefit();
            }
            
            employee.Benefit.CostOfBenefitDependent = employee.Dependents.Count * _costOfBenefit;
        }
    }
}
