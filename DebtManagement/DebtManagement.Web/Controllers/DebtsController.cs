using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DebtController : ControllerBase
    {
        private readonly IDebtService _debtService;
        private readonly IMapper _mapper;

        public DebtController(IDebtService debtService, IMapper mapper)
        {
            _debtService = debtService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DebtDTO>>> GetDebts()
        {
            var debts = await _debtService.GetAllDebtsAsync();
            return Ok(_mapper.Map<IEnumerable<DebtDTO>>(debts));
        }

        // Other actions like GetDebtById, AddDebt, UpdateDebt, DeleteDebt
    }
}
