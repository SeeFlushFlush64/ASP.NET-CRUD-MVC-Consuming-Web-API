using System.ComponentModel;

namespace CRUDMVCusingWebAPI.Models
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Employee Name")]
        public required string Name { get; set; }
        [DisplayName("Employee Email")]
        public required string Email { get; set; }
        [DisplayName("Phone Number")]
        public string? Phone { get; set; }
        [DisplayName("Salary")]
        public decimal Salary { get; set; }
    }
}
