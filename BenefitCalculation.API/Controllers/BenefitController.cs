using BenefitCalculation.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BenefitCalculation.Contracts.Models;

namespace BenefitCalculation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitController : ControllerBase
    {        
        private ICalculateBenefitForEmployees _calculateBenefitForEmployees;
        private ICalculateDiscountForEmployees _calculateDiscountForEmployees;
        private ICalculateBenefitPayPeroidForEmployees _calculatePayPeriod;
        public BenefitController(ICalculateBenefitForEmployees calculateBenefitForEmployees, ICalculateDiscountForEmployees calculateDiscountForEmployees, ICalculateBenefitPayPeroidForEmployees calculatePayPeriod)
        {            
            _calculateBenefitForEmployees = calculateBenefitForEmployees;
            _calculateDiscountForEmployees = calculateDiscountForEmployees;
            _calculatePayPeriod = calculatePayPeriod;
        }

      
        [HttpPost]
        public IActionResult Post([FromBody] IEnumerable<Employee> employees)
        {
            var employeesCalculation = employees.Cast<IEmployee>().ToList();
            _calculateBenefitForEmployees.Calculate(employeesCalculation);
            _calculateDiscountForEmployees.CalculateEmployeeDiscount(employeesCalculation);
            _calculatePayPeriod.Calculate(employeesCalculation);
            return Ok(employeesCalculation);
        }  
    }
}
