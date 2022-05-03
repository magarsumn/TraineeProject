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
    public class OvertimeController : ControllerBase
    {
        private readonly IRepository<Overtime> _overTimeRepository;

        public OvertimeController(IRepository<Overtime> overTimeRepository)
        {
            _overTimeRepository = overTimeRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _overTimeRepository.GetAllListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _overTimeRepository.FirstOrDefaultAsync(a => a.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Overtime department)
        {
            _overTimeRepository.Add(department);
            await _overTimeRepository.SaveChangesAsync();
            return Ok(department);
        }

        [HttpPut]
        public async Task<IActionResult> Put(OvertimeDtos input)
        {
            var data = await _overTimeRepository.FirstOrDefaultAsync(a => a.Id == input.Id);
            if (data == null)
            {
                return NotFound();
            }
            
            data.EmployeeId=input.EmployeeId;
            data.Months=input.Months;
            data.Amount=input.Amount;
            data.Remarks=input.Remarks;
            await _overTimeRepository.UpdateAsync(data);
            return Ok(data);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _overTimeRepository.FirstOrDefaultAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            await _overTimeRepository.DeleteAsync(id);
            return Ok("Item Deleted");
        }
    }
}
