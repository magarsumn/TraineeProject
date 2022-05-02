using System.ComponentModel.DataAnnotations.Schema;
using HRApp.Server.Repository;

namespace HRApp.Server.Models
{
    [Table("tbl_Employees")]
    public class Employees : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        //public byte[] Photo { get; set; }
        public decimal Salary { get; set; }
        public DateTime? HireDate { get; set; }
      
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? DepartmentFk { get; set; }
        public int DesignationId { get; set; }
        [ForeignKey("DesignationId")]
        public virtual Designation? DesignationFk { get; set; }
    }

    public enum Gender
    {
        Male=1,
        Female=2,
        Others=3,
    }
}
