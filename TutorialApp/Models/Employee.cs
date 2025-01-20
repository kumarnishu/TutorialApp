namespace TutorialApp.Models
{
    // File: Modules/Employees/Models/Employee.cs

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public Guid TenantId { get; set; } // Optional: For multi-tenancy support
    }

}
