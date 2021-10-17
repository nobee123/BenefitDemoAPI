using BenefitCalculation.Contracts.Interfaces;
using BenefitCalculation.Contracts.Models;
using System.Linq;

namespace FirstNameDiscountCalculation
{
    public class FirstNameDiscountCalculate : ICalculateBenefitDiscount
    {
        private decimal _discountPercentage;
        private string _firstNameCharacterDiscountQualifiation;
        public FirstNameDiscountCalculate(decimal discountPercentage, string firstNameCharacterDiscountQualifiation)
        {
            _discountPercentage = discountPercentage;
            _firstNameCharacterDiscountQualifiation = firstNameCharacterDiscountQualifiation;
        }
        public void CalculateDiscount(IEmployee employee)
        {            
            if (VerifyQualification(employee))
            {
                if (employee.Benefit == null)
                {
                    employee.Benefit = new Benefit();
                }
                employee.Benefit.BenefitDiscountAmount = ApplyDiscount(employee.Benefit.CostOfBenefitEmployee + employee.Benefit.CostOfBenefitDependent);
                return; //applied the 10% discount one time no need to check for dependent
            }
            if (employee.Dependents == null || !employee.Dependents.Any())
            {
                return; // No dependents to verify
            }

            VerifyDependentQualification(employee);           
        }

        private void VerifyDependentQualification(IEmployee employee)
        {
            if (employee.Dependents.Any(x => VerifyQualification(x)))
            {
                if (employee.Benefit == null)
                {
                    employee.Benefit = new Benefit();
                }
                employee.Benefit.BenefitDiscountAmount = ApplyDiscount(employee.Benefit.CostOfBenefitEmployee + employee.Benefit.CostOfBenefitDependent);
            }
        }

        private decimal ApplyDiscount(decimal costOfBenfit)
        {
            return costOfBenfit * _discountPercentage;
        }

        private bool VerifyQualification(IPerson person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                return false;
            }            
            if (person.FirstName.ToLower()[0] != _firstNameCharacterDiscountQualifiation.ToLower()[0])
            {
                return false;
            }

            return true;
        }
    }
}
