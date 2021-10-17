using BenefitCalculation.Contracts.Interfaces;
using BenefitCalculation.Contracts.Models;
using DependentCalculation;
using EmployeeCostOfBenefitCalculation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitCalculation.Service
{    
    public class CalculateBenefitForEmployees : ICalculateBenefitForEmployees
    {
        private List<ICalculateBenefit> _calculateBenefits;
        private CostOfBenefitConfiguration _costOfBenefitConfiguration;        

        public CalculateBenefitForEmployees(IOptions<CostOfBenefitConfiguration> costOfBenefitConfiguration )
        {
            _calculateBenefits = new List<ICalculateBenefit>();
            _costOfBenefitConfiguration = costOfBenefitConfiguration.Value;
            GenerateBenefitCalculationModules();
        }

        public void Calculate(List<IEmployee> employees)
        {
            foreach (var employee in employees)
            {
                _calculateBenefits.ForEach(x => x.CalculateBenefit(employee));
            }           
        }
        private void GenerateBenefitCalculationModules()
        {
            _calculateBenefits.Add(new DependentCostCalculation(_costOfBenefitConfiguration.Dependent));
            _calculateBenefits.Add(new CostOfBenefitCalculation(_costOfBenefitConfiguration.Employee));

        }
    }
}
