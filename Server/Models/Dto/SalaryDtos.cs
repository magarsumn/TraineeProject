using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRApp.Server.Models;
using HRApp.Server.Repository;

namespace WebAssembly.Shared.Models.Dto
{
    public class SalaryDtos : EntityBase
    {
        public int EmployeeId { get; set; }
        public Months Months { get; set; }
        public decimal BasicSalary { get; set; }
        public string Bonus { get; set; }
        public string Deduction { get; set; }
        public int OverTime { get; set; }
        public decimal NetAmount { get; set; }
        public Status Status { get; set; }
    }
}
