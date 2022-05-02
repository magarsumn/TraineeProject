using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRApp.Server.Repository;

namespace WebAssembly.Shared.Models.Dto
{
    public class DepartmentDtos : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
