using Microsoft.AspNetCore.Mvc;
using TutorialApp.Data;
using TutorialApp.DTOs;
using TutorialApp.Models;
using TutorialApp.Repositories;

namespace TutorialApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeesController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return Ok(employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Salary = e.Salary
            }));
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Salary = employee.Salary
            });
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployee(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Salary = employeeDto.Salary
            };

            await _employeeRepository.AddEmployeeAsync(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employeeDto);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Id = id,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Salary = employeeDto.Salary
            };

            await _employeeRepository.UpdateEmployeeAsync(employee);
            return NoContent();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }

}
