using System.Collections.Generic;
using BenefitCalculation.Contracts.Models;
using DependentCalculation;
using NUnit.Framework;

namespace Tests
{
    public class GivenEmployeeWithDependent
    {
        private Employee _employee;
        private decimal _dependentBenefitCost;
        [SetUp]
        public void Setup()
        {
            _employee = new Employee
            {
                Dependents = new List<Dependent>
                {
                    new Dependent
                    {
                        FirstName ="Alan",
                        LastName ="Yuen"
                    },
                    new Dependent
                    {
                        FirstName = "John",
                        LastName ="Don"
                    },
                  
                },
                Benefit = new Benefit()
            };
            _dependentBenefitCost = 500;
        }

        [Test]
        public void Given_Two_Dependent_Benefit_Calculation()
        {
            var test = new DependentCostCalculation(_dependentBenefitCost);
            test.CalculateBenefit(_employee);
            Assert.AreEqual(1000, _employee.Benefit.CostOfBenefitDependent);
        }
    }

   
}