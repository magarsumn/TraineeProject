using HRApp.Server.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Server.Models
{
    [Table("tbl_Overtimes")]
    public class Overtime : EntityBase
    {
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")] public Employees EmployeesFk { get; set; }
        public Months Months { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
    }
}
