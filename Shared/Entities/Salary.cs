
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Shared.Entities
{
    
    public class Salary 
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Months Months { get; set; }
        public decimal BasicSalary { get; set; }
        public string Bonus { get; set; }
        public string Deduction { get; set; }
        public int OverTime { get; set; }
        public decimal NetAmount { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        Pending=1,
        Paid=2
    }
}
