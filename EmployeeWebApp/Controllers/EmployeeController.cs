using Microsoft.AspNetCore.Mvc;
//using EData.MyProjects;
using EmployeeWebApp.Business;
using EmployeeWebApp.Models;

namespace EmployeeWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeBusiness _employeeBusiness;

        public EmployeeController(EmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }
        //
        [HttpGet]
        [Route("GetList")]
        public IActionResult GetList()
        {
            var employees = _employeeBusiness.GetEmployees();
            return Ok(employees);
        }

        //
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Employee employee)
        {
            _employeeBusiness.AddEmployee(employee);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Employee employee)
        {
            _employeeBusiness.UpdateEmployee(employee);
            return Ok();
        }

        // for 2nd heighest salary
        [HttpGet]
        [Route("GetSecondHighestSalary")]
        public IActionResult GetSecondHighestSalary()
        {
            var employee = _employeeBusiness.GetEmployeeWithNthHighestSalary(2);
            return Ok(employee);
        }

        //get by date
        [HttpGet]
        [Route("GetByDate")]
        public IActionResult GetByDate(DateTime startDate, DateTime endDate)
        {
            var employees = _employeeBusiness.GetEmployeesJoinedInRange(startDate, endDate);
            return Ok(employees);
        }
    }
}
