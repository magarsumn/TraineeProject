using HRApp.Server.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Server.Models
{
    [Table("tbl_Departments")]
    public class Department : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
