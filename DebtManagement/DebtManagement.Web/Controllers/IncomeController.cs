using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;
        private readonly IMapper _mapper;

        public IncomeController(IIncomeService incomeService, IMapper mapper)
        {
            _incomeService = incomeService;
            _mapper = mapper;
        }

        // GET: api/Income
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeDto>>> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllIncomesAsync();
            return Ok(incomes);
        }

        // GET: api/Income/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeDto>> GetIncomeById(int id)
        {
            var income = await _incomeService.GetIncomeByIdAsync(id);

            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }

        // POST: api/Income
        [HttpPost]
        public async Task<ActionResult> AddIncome(IncomeDto incomeDto)
        {
            await _incomeService.AddIncomeAsync(incomeDto);
            return CreatedAtAction(nameof(GetIncomeById), new { id = incomeDto.Id }, incomeDto);
        }

        // PUT: api/Income/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIncome(int id, IncomeDto incomeDto)
        {
            if (id != incomeDto.Id)
            {
                return BadRequest();
            }

            await _incomeService.UpdateIncomeAsync(incomeDto);
            return NoContent();
        }

        // DELETE: api/Income/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            await _incomeService.DeleteIncomeAsync(id);
            return NoContent();
        }
    }
}
