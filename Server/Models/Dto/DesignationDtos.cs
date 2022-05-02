using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRApp.Server.Repository;

namespace WebAssembly.Shared.Models.Dto
{
    public class DesignationDtos : EntityBase
    {
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string Description { get; set; }
    }
}
