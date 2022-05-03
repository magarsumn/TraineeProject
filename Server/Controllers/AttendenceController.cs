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
    public class AttendenceController : ControllerBase
    {
        private readonly IRepository<Attendence> _attendenceRepository;

        public AttendenceController(IRepository<Attendence> attendenceRepository)
        {
            _attendenceRepository = attendenceRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _attendenceRepository.GetAllListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _attendenceRepository.FirstOrDefaultAsync(a => a.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Attendence attendence)
        {
            _attendenceRepository.Add(attendence);
            await _attendenceRepository.SaveChangesAsync();
            return Ok(attendence);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AttendenceDtos input)
        {
            var data = await _attendenceRepository.FirstOrDefaultAsync(a => a.Id == input.Id);
            if (data == null)
            {
                return NotFound();
            }
            
            data.Date = input.Date;
            data.EmployeeId=input.EmployeeId;
            data.Status=input.Status;
            data.Remarks=input.Remarks;
            await _attendenceRepository.UpdateAsync(data);
            return Ok(data);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _attendenceRepository.FirstOrDefaultAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            await _attendenceRepository.DeleteAsync(id);
            return Ok("Item Deleted");
        }
    }
}
