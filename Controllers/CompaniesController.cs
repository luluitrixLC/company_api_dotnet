using Company_Api.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Company_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
       private readonly DatabaseContext _context; 

       public CompaniesController(DatabaseContext context)
       {
           _context = context;
       }
       
       [HttpGet] //https://localhost:5001/api/companies/1 
       public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
       {
           return await _context.Companies.ToListAsync();
       }

       [HttpGet("{id}")] //https://localhost:5001/api/companies/1
       public async Task<ActionResult<Company>> GetCompany(long id)
       {
           var company = await _context.Companies.FindAsync(id);

           if(company == null){
               return NotFound();
           }
           return company;
       }

       [HttpGet("{id}/branches")] //https://localhost:5001/api/companies/1/branches
       public async Task<ActionResult<IEnumerable<Branch>>> GetCompanyBranches(long id)
       {
           return await _context.Branches.Where(b=> b.CompanyId == id).ToListAsync();
       }

       [HttpPost] //https://localhost:5001/api/companies/
       public async Task<ActionResult<Company>> PostCompany(Company company)
       {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id}, company);
       }

       [HttpDelete("{id}")]
       public async Task<ActionResult<Company>> DeleteCompany(long id){
           var company = await _context.Companies.FindAsync(id);

           if(company == null){
               return NotFound();
           }
           
           _context.Companies.Remove(company);
           await _context.SaveChangesAsync();
           return company;
       }

        [HttpPut("{id}")]
       public async Task<ActionResult<Company>> UpdateCompany(long id, Company company){
           if(id != company.Id){
               return BadRequest();
           }
           _context.Entry(company).State = EntityState.Modified;
           await _context.SaveChangesAsync();
           return CreatedAtAction("GetCompany", new {id = company.Id}, company);
       }
    }
}