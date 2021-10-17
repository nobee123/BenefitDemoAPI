using BenefitCalculation.Contracts.Interfaces;
using BenefitCalculation.Contracts.Models;
using BenefitCalculation.Service;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class GivenBenefitByPayPeriod
    {
        private List<Employee> _employees;
        private IOptions<CalculatePayPeriodConfiguration> _config;
        [SetUp]
        public void Setup()
        {
            _employees = new List<Employee>
            {
                new Employee
                {
                    Benefit = new Benefit
                    {
                        CostOfBenefitEmployee = 1000
                    },
                    PayAmount = 2000

                }
            };
            _config = Options.Create(new CalculatePayPeriodConfiguration { NumberOfPeriod = 1});
        }

        [Test]
        public void Given_one_Pay_Period()
        {
            var test = new CalculateBenefitByPayPeriod(_config);
            test.Calculate(_employees.Cast<IEmployee>().ToList());
            var employee = _employees.First();
            Assert.AreEqual(1000, employee.Benefit.CostOfBenefitPerPayPeriod);
            
        }
    }
}