using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Shared.Entities
{
    public class Employees
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        //public byte[] Photo { get; set; }
        public decimal Salary { get; set; }
        public DateTime? HireDate { get; set; }

        public int DepartmentId { get; set; }
        
        public Department? DepartmentFk { get; set; }
        public int DesignationId { get; set; }
        public virtual Designation? DesignationFk { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Others = 3,
    }
}
