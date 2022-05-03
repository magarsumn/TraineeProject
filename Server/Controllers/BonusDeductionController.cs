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
    public class BonusDeductionController : ControllerBase
    {
        private readonly IRepository<BonusDeduction> _bonusDeductionRepository;

        public BonusDeductionController(IRepository<BonusDeduction> bonusDeductionRepository)
        {
            _bonusDeductionRepository = bonusDeductionRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _bonusDeductionRepository.GetAllListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _bonusDeductionRepository.FirstOrDefaultAsync(a => a.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BonusDeduction bonus)
        {
            _bonusDeductionRepository.Add(bonus);
            await _bonusDeductionRepository.SaveChangesAsync();
            return Ok(bonus);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BonusDeductionDtos input)
        {
            var data = await _bonusDeductionRepository.FirstOrDefaultAsync(a => a.Id == input.Id);
            if (data == null)
            {
                return NotFound();
            }
            
            data.EmployeeId=input.EmployeeId;
            data.Months=input.Months;
            data.Bonus=input.Bonus;
            data.Deduction=input.Deduction;
            data.Remarks=input.Remarks;
            await _bonusDeductionRepository.UpdateAsync(data);
            return Ok(data);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _bonusDeductionRepository.FirstOrDefaultAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            await _bonusDeductionRepository.DeleteAsync(id);
            return Ok("Item Deleted");
        }
    }
}
