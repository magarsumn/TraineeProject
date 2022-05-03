using HRApp.Server.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Server.Models
{
    [Table("tbl_Salary")]
    public class Salary : EntityBase
    {
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")] public Employees EmployeesFk { get; set; }
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
