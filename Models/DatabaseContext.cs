using Microsoft.EntityFrameworkCore;

namespace Company_Api.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        //tabla de branches
        public DbSet<Branch> Branches {get; set;}

        //tabla de companies
        public DbSet<Company> Companies {get; set;}

        //tabla de employees
        public DbSet<Employee> Employees {get; set;}


    }
}