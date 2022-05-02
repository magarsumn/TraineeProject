using System.Threading.Tasks;
using HRApp.Server.Models;
using HRApp.Server.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAssembly.Shared.Models;
using WebAssembly.Shared.Models.Dto;

namespace HRApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employees> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Designation> _designationRepository;

        public EmployeesController(IRepository<Employees> employeeRepository,
            IRepository<Department> departmentRepository,
            IRepository<Designation> designationRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _designationRepository = designationRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _employeeRepository.GetAllListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _employeeRepository.FirstOrDefaultAsync(a => a.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employees employee)
        {
            _employeeRepository.Add(employee);
            await _employeeRepository.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EmployeeDtos input)
        {
            var data = await _employeeRepository.FirstOrDefaultAsync(a => a.Id == input.Id);
            if (data == null)
            {
                return NotFound();
            }
            
            data.Name = input.EmployeeName;
            data.Address = input.Address;
            data.Email = input.Email;
            data.Phone = input.Phone;
            data.Gender = input.Gender;
            data.Salary=input.Salary;
            data.HireDate = input.HireDate;
            data.DepartmentId=input.DepartmentId;
            data.DesignationId=input.DesignationId;

            await _employeeRepository.UpdateAsync(data);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _employeeRepository.FirstOrDefaultAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            await _employeeRepository.DeleteAsync(id);
            return Ok($"Employee of Id No {id} Deleted Successfully");
        }

        [HttpGet("department")]
        public async Task<List<DepartmentDropdownDto>> GetDepartmentDropdown()
        {
            return await _departmentRepository.GetAll().Select(dep => new DepartmentDropdownDto
            {
                Id = dep.Id,
                Name = dep.Name,
            }).ToListAsync();
        }

        [HttpGet("designation")]
        public async Task<List<DesignationDropdownDto>> GetDesignationDropdown()
        {
            return await _designationRepository.GetAll().Select(deg => new DesignationDropdownDto
            {
                Id = deg.Id,
                Name = deg.Name,
            }).ToListAsync();
        }
    }
}
