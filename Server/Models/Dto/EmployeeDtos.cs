using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRApp.Server.Models;
using HRApp.Server.Repository;
namespace WebAssembly.Shared.Models.Dto
{
    public class EmployeeDtos : EntityBase
    {
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Sex Gender { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
    }
}
