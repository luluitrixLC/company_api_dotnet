using System.Collections.Generic;

namespace Company_Api.Models
{
    public class Branch
    {
        public long Id {get; set;}

        public string Name {get; set;}

        public string Phone {get; set;}

        public bool IsActive {get; set;}

        public long CompanyId {get; set;}

        public Company Company {get; set;}

        public List<Employee> employees {get; set;}

    }
}