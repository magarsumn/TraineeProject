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
    public class SalaryController : ControllerBase
    {
        private readonly IRepository<Salary> _salaryRepository;

        public SalaryController(IRepository<Salary> salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _salaryRepository.GetAllListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _salaryRepository.FirstOrDefaultAsync(a => a.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Salary salary)
        {
            _salaryRepository.Add(salary);
            await _salaryRepository.SaveChangesAsync();
            return Ok(salary);
        }

        [HttpPut]
        public async Task<IActionResult> Put(SalaryDtos input)
        {
            var data = await _salaryRepository.FirstOrDefaultAsync(a => a.Id == input.Id);
            if (data == null)
            {
                return NotFound();
            }
            
            data.EmployeeId=input.EmployeeId;
            data.Months=input.Months;
            data.BasicSalary=input.BasicSalary;
            data.Bonus=input.Bonus;
            data.Deduction = input.Deduction;
            data.OverTime=input.OverTime;
            data.NetAmount=input.NetAmount;
            data.Status=input.Status;
            await _salaryRepository.UpdateAsync(data);
            return Ok(data);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _salaryRepository.FirstOrDefaultAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            await _salaryRepository.DeleteAsync(id);
            return Ok("Item Deleted");
        }
    }
}
