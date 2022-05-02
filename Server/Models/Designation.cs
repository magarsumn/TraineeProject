using HRApp.Server.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Server.Models
{
    [Table("tbl_Designations")]
    public class Designation : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? DepartmentFk { get; set; }

    }
}
