using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRApp.Server.Repository;

namespace WebAssembly.Shared.Models.Dto
{
    public class AttendenceDtos : EntityBase
    {
        public DateTime? Date { get; set; }
        public int EmployeeId { get; set; }
        public bool Status { get; set; }
        public string Remarks { get; set; }
    }
}
