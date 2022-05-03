using HRApp.Server.Models;
using HRApp.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IRepository<Employees> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Designation> _designationRepository;

        public DashboardController(
            IRepository<Employees> employeeRepository,
            IRepository<Department> departmentRepository,
            IRepository<Designation> designationRepository
            )
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _designationRepository = designationRepository;
        }

        [HttpGet("DepCount")]
        public async Task<int> DepartmetCount()
        {
            return await _departmentRepository.CountAsync();
        }

        [HttpGet("DegCount")]
        public async Task<int> DeginationCount()
        {
            return await _designationRepository.CountAsync();
        }
        [HttpGet("EmpCount")]
        public async Task<int> EmployeeCount()
        {
            return await _employeeRepository.CountAsync();
        }
    }
}
