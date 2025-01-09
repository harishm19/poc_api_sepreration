using Microsoft.AspNetCore.Mvc;
using POC_employee_Dpt.Models;
using POC_employee_Dpt.Services;

namespace POC_employee_Dpt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(IConfiguration configuration)
        {
            _employeeService = new EmployeeService(configuration.GetConnectionString("EmployeeManagementDb"));
        }
        [HttpGet("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }
        
        [HttpPost("GetEmployeeDepartmentByEmpID")]
        public async Task<IActionResult> GetEmployeeDepartment([FromBody] List<Employee> employees)
        {
            var result = await _employeeService.GetEmployeeDepartmentsAsync(employees);
            return Ok(result);
        }
    }
}
