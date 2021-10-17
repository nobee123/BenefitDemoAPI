using System;
using System.Collections.Generic;
using System.Text;

namespace BenefitCalculation.Contracts.Interfaces
{
    public interface ICalculateBenefitPayPeroidForEmployees
    {
        void Calculate(List<IEmployee> employees);
    }
}
