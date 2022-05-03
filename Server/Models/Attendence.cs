using HRApp.Server.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Server.Models
{
    [Table("tbl_Attendences")]
    public class Attendence : EntityBase
    {
        public DateTime? Date { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")] public Employees EmployeesFk { get; set; }
        public bool Status { get; set; }
        public string Remarks { get; set; }
    }
}
