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
    public class BranchesController : ControllerBase
    {
       private readonly DatabaseContext _context; 

       public BranchesController(DatabaseContext context)
       {
           _context = context;
       }
       
       [HttpGet] //https://localhost:5001/api/branches/1 
       public async Task<ActionResult<IEnumerable<Branch>>> GetBranches()
       {
           return await _context.Branches.ToListAsync();
       }

       [HttpGet("{id}")] //https://localhost:5001/api/branches/1
       public async Task<ActionResult<Branch>> GetBranch(long id)
       {
           var branch = await _context.Branches.FindAsync(id);

           if(branch == null){
               return NotFound();
           }
           return branch;
       }

       [HttpPost] //https://localhost:5001/api/branches/
       public async Task<ActionResult<Branch>> PostBranch(Branch branch)
       {
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranch", new { id = branch.Id}, branch);
       }

       [HttpDelete("{id}")]
       public async Task<ActionResult<Branch>> DeleteBranch(long id){
           var branch = await _context.Branches.FindAsync(id);

           if(branch == null){
               return NotFound();
           }
           _context.Branches.Remove(branch);
           await _context.SaveChangesAsync();
           return branch;
       }

        [HttpPut("{id}")]
       public async Task<ActionResult<Branch>> UpdateBranch(long id, Branch branch){
           if(id != branch.Id){
               return BadRequest();
           }
           _context.Entry(branch).State = EntityState.Modified;
           await _context.SaveChangesAsync();
           return CreatedAtAction("GetBranch", new {id = branch.Id}, branch);
       }
    }
}