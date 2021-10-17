using BenefitCalculation.Contracts.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        private Employee _employee;
        private decimal _discountPercentage;
        private string _qualifyDiscountCharacter;
        
        [SetUp]
        public void Setup()
        {
            _discountPercentage = (decimal).10;
            _qualifyDiscountCharacter = "a";
            _employee = new Employee
            {
                FirstName = "alan",
                LastName = "yuen",
                Benefit = new Benefit()

            };
            _employee.Benefit.CostOfBenefitEmployee = 1000;
        }

        [Test]
        public void Given_FirstName_Match_For_Employee_Receive_10_Percent_Discount()
        {
            var firstNameDiscount = new FirstNameDiscountCalculation.FirstNameDiscountCalculate(_discountPercentage, _qualifyDiscountCharacter);
            firstNameDiscount.CalculateDiscount(_employee);
            Assert.AreEqual(100, _employee.Benefit.BenefitDiscountAmount);
        }

        [Test]
        public void Given_FirstName_Match_For_Employee_Capital_FirstName_Receive_10_Percent_Discount()
        {
            _employee.FirstName = "Alen";
            var firstNameDiscount = new FirstNameDiscountCalculation.FirstNameDiscountCalculate(_discountPercentage, _qualifyDiscountCharacter);
            firstNameDiscount.CalculateDiscount(_employee);
            Assert.AreEqual(100, _employee.Benefit.BenefitDiscountAmount);
        }

        [Test]
        public void Given_FirstName_Match_On_Dependent_With_Discount()
        {
            _employee.FirstName = "Ken";
            _employee.Dependents = new List<Dependent>
            {
                new Dependent{ FirstName = "alan"}
            };
            var firstNameDiscount = new FirstNameDiscountCalculation.FirstNameDiscountCalculate(_discountPercentage, _qualifyDiscountCharacter);
            firstNameDiscount.CalculateDiscount(_employee);
            Assert.AreEqual(100, _employee.Benefit.BenefitDiscountAmount);
        }
        [Test]
        public void Given_FirstName_NotMatch_Employee_No_Dependent_No_Discount()
        {
            _employee.FirstName = "Ken";
            var firstNameDiscount = new FirstNameDiscountCalculation.FirstNameDiscountCalculate(_discountPercentage, _qualifyDiscountCharacter);
            firstNameDiscount.CalculateDiscount(_employee);
            Assert.AreEqual(0, _employee.Benefit.BenefitDiscountAmount);
        }       

        [Test]
        public void Given_FirstName_No_Match__Dependent_Employee_No_Discount()
        {
            _employee.FirstName = "Ken";
            _employee.Dependents = new List<Dependent>
            {
                new Dependent{ FirstName = "Jason"}
            };
            var firstNameDiscount = new FirstNameDiscountCalculation.FirstNameDiscountCalculate(_discountPercentage, _qualifyDiscountCharacter);
            firstNameDiscount.CalculateDiscount(_employee);
            Assert.AreEqual(0, _employee.Benefit.BenefitDiscountAmount);
        }
    }   
}