using BenefitCalculation.Contracts.Interfaces;
using BenefitCalculation.Contracts.Models;
using FirstNameDiscountCalculation;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace BenefitCalculation.Service
{
    public class CalculateDiscountForEmployees : ICalculateDiscountForEmployees
    {
        private FirstNameDiscountConfiguration _firstNameDiscountConfiguration;
        private List<ICalculateBenefitDiscount> _calculateBenefitDiscounts;
        public CalculateDiscountForEmployees(IOptions<FirstNameDiscountConfiguration> firstNameDiscount)
        {
            _firstNameDiscountConfiguration = firstNameDiscount.Value;
            _calculateBenefitDiscounts = new List<ICalculateBenefitDiscount>();
            GenerateBenefitCalculationModules();
        }      
        public void CalculateEmployeeDiscount(List<IEmployee> employees)
        {
            employees.ForEach(x => _calculateBenefitDiscounts.ForEach(y => y.CalculateDiscount(x)));
        }
        private void GenerateBenefitCalculationModules()
        {
            _calculateBenefitDiscounts.Add(new FirstNameDiscountCalculate(_firstNameDiscountConfiguration.Percentage, _firstNameDiscountConfiguration.Character));
        }
    }
    
}
