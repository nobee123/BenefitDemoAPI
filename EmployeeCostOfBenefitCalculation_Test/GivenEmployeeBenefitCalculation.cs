using BenefitCalculation.Contracts.Interfaces;
using BenefitCalculation.Contracts.Models;
using EmployeeCostOfBenefitCalculation;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private IEmployee _employee;
        private decimal _costOfBenefit;
        [SetUp]
        public void Setup()
        {
            _employee = new Employee
            {
                Benefit = new Benefit()
            };
            _costOfBenefit = 1000;
        }

        [Test]
        public void Given_Employee_Cost_Of_Benefit_Calculation()
        {
            var test = new CostOfBenefitCalculation(_costOfBenefit);
            test.CalculateBenefit(_employee);
            Assert.AreEqual(1000, _employee.Benefit.CostOfBenefitEmployee);
        }        
    }
}