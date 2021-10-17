using BenefitCalculation.Contracts.Interfaces;

namespace BenefitCalculation.Contracts.Models
{
    public class Dependent : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
