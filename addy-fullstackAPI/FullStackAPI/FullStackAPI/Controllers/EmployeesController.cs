using FullStackAPI.Data;
using FullStackAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly FullStackDbContext _fullStackDbcontext;
        public EmployeesController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbcontext = fullStackDbContext;   
        }
        [HttpGet]
        public async Task <IActionResult> GetAllEmployees()
        {
            var employees = await _fullStackDbcontext.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
        {
            employeeRequest.Id =Guid.NewGuid();
            await _fullStackDbcontext.Employees.AddAsync(employeeRequest);
            await _fullStackDbcontext.SaveChangesAsync();
            return Ok(employeeRequest);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
           var employee= await _fullStackDbcontext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(employee==null)
            {
                return NotFound();  
            }
            return Ok(employee);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id,Employee updateEmployeeRequest)
        {
            var employee = await _fullStackDbcontext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeRequest.Name;
            employee.Email = updateEmployeeRequest.Email;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Phone = updateEmployeeRequest.Phone;
            employee.Department = updateEmployeeRequest.Department;
            await _fullStackDbcontext.SaveChangesAsync();  
            return Ok(employee);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _fullStackDbcontext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _fullStackDbcontext.Employees.Remove(employee);
            await _fullStackDbcontext.SaveChangesAsync();
            return Ok(employee);
        }
    }
    }
 
