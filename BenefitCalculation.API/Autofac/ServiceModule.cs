using Autofac;
using BenefitCalculation.Contracts.Interfaces;
using BenefitCalculation.Service;

namespace BenefitCalculation.API.Autofac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {   
            builder.RegisterType<CalculateBenefitForEmployees>().As<ICalculateBenefitForEmployees>();
            builder.RegisterType<CalculateDiscountForEmployees>().As<ICalculateDiscountForEmployees>();
            builder.RegisterType<CalculateBenefitByPayPeriod>().As<ICalculateBenefitPayPeroidForEmployees>();                        
        }
    }
}
