using System.Collections.Generic;

namespace Company_Api.Models
{
    public class Company
    {
        public long Id {get; set;}

        public string Name {get; set;}
        
        public string Phone {get; set;}

        public string Email {get; set;}

        public long GovermentId {get; set;}
        
        public List<Branch> branches {get; set;}
    }
}