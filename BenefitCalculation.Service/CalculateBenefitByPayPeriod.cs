using BenefitCalculation.Contracts.Interfaces;
using BenefitCalculation.Contracts.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace BenefitCalculation.Service
{
    public class CalculateBenefitByPayPeriod : ICalculateBenefitPayPeroidForEmployees
    {
        private CalculatePayPeriodConfiguration _payPeriod;
        public CalculateBenefitByPayPeriod(IOptions<CalculatePayPeriodConfiguration> calculatePayPeriodConfiguration)
        {
            _payPeriod = calculatePayPeriodConfiguration.Value;
        }

        public void Calculate(List<IEmployee> employees)
        {
            employees.ForEach(x => CalculateBenefit(x));
        }

        private void CalculateBenefit(IEmployee employee)
        {
            employee.Benefit.TotalBenefitAmount = employee.Benefit.CostOfBenefitEmployee + employee.Benefit.CostOfBenefitDependent - employee.Benefit.BenefitDiscountAmount;
            employee.Benefit.CostOfBenefitPerPayPeriod =  Math.Round((employee.Benefit.TotalBenefitAmount / _payPeriod.NumberOfPeriod), 2);

            if (employee.PayAmount <= 0)
            {
                return;
            }
            var payCheckAmountAfterBenefit = employee.PayAmount - employee.Benefit.CostOfBenefitPerPayPeriod;
            if (payCheckAmountAfterBenefit <= 0)
            {
                employee.Benefit.PayCheckAmountAfterBenefit = 0;
                return;
            }
            employee.Benefit.PayCheckAmountAfterBenefit = payCheckAmountAfterBenefit;
        }
    }
}
