namespace Company_Api.Models
{
    public class Employee
    {
        public long Id {get; set;}

        public string Name {get; set;}

        public string Phone {get; set;}

        public string Address {get; set;}

        public bool IsActive {get; set;}
        
        public long BranchId {get; set;}
        public Branch Branch {get; set;}

    }
}