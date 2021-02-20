using Company_Api.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Company_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
       private readonly DatabaseContext _context; 

       public EmployeesController(DatabaseContext context)
       {
           _context = context;
       }
       
       [HttpGet] //https://localhost:5001/api/employees/1 
       public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
       {
           return await _context.Employees.ToListAsync();
       }

       [HttpGet("{id}")] //https://localhost:5001/api/employees/1
       public async Task<ActionResult<Employee>> GetEmployee(long id)
       {
           var employee = await _context.Employees.FindAsync(id);

           if(employee == null){
               return NotFound();
           }
           return employee;
       }

       [HttpPost] //https://localhost:5001/api/employees/
       public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
       {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id}, employee);
       }

       [HttpDelete("{id}")]
       public async Task<ActionResult<Employee>> DeleteEmployee(long id){
           var employee = await _context.Employees.FindAsync(id);

           if(employee == null){
               return NotFound();
           }
           _context.Employees.Remove(employee);
           await _context.SaveChangesAsync();
           return employee;
       }

        [HttpPut("{id}")]
       public async Task<ActionResult<Employee>> UpdateEmployee(long id, Employee employee){
           if(id != employee.Id){
               return BadRequest();
           }
           _context.Entry(employee).State = EntityState.Modified;
           await _context.SaveChangesAsync();
           return CreatedAtAction("GetEmployee", new {id = employee.Id}, employee);
       }
    }
}