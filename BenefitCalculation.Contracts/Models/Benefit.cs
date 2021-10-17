namespace BenefitCalculation.Contracts.Models
{
    public class Benefit
    {  
        public decimal CostOfBenefitEmployee { get; set; }
        public decimal CostOfBenefitDependent { get; set; }
        public decimal BenefitDiscountAmount { get; set; }
        public decimal CostOfBenefitPerPayPeriod { get; set; }
        public decimal TotalBenefitAmount { get; set; }
        public decimal PayCheckAmountAfterBenefit { get; set; }
    }
}
