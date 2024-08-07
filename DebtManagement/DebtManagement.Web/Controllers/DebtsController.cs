/*using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DebtManagement.Web.Entities;

namespace DebtManagement.Web.Controllers
{
    public class DebtsController : Controller
    {
        private readonly IDebtService _debtService;
        private readonly IMapper _mapper;

        public DebtsController(IDebtService debtService, IMapper mapper)
        {
            _debtService = debtService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var debts = await _debtService.GetAllDebtsAsync();
            var debtDtos = _mapper.Map<IEnumerable<DebtDTO>>(debts);
            return View(debtDtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DebtDTO debtDto)
        {
            if (ModelState.IsValid)
            {
                var debt = _mapper.Map<Debt>(debtDto);
                await _debtService.AddDebtAsync(debt);
                return RedirectToAction(nameof(Index));
            }
            return View(debtDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                return NotFound();
            }
            var debtDto = _mapper.Map<DebtDTO>(debt);
            return View(debtDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DebtDTO debtDto)
        {
            if (id != debtDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var debt = _mapper.Map<Debt>(debtDto);
                await _debtService.UpdateDebtAsync(debt);
                return RedirectToAction(nameof(Index));
            }
            return View(debtDto);
        }

        public async Task<IActionResult> Details(int id)
        {
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                return NotFound();
            }
            var debtDto = _mapper.Map<DebtDTO>(debt);
            return View(debtDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                return NotFound();
            }
            var debtDto = _mapper.Map<DebtDTO>(debt);
            return View(debtDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _debtService.DeleteDebtAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
*/
using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DebtManagement.Web.Entities;
using Microsoft.Extensions.Logging;

namespace DebtManagement.Web.Controllers
{
    public class DebtsController : Controller
    {
        private readonly IDebtService _debtService;
        private readonly IMapper _mapper;
        private readonly ILogger<DebtsController> _logger;

        public DebtsController(IDebtService debtService, IMapper mapper, ILogger<DebtsController> logger)
        {
            _debtService = debtService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index method called.");
            var debts = await _debtService.GetAllDebtsAsync();
            if (debts == null || !debts.Any())
            {
                _logger.LogWarning("No debts found.");
            }
            else
            {
                _logger.LogInformation($"Number of debts found: {debts.Count()}");
            }

            var debtDtos = _mapper.Map<IEnumerable<DebtDTO>>(debts);
            return View(debtDtos);
        }

        public IActionResult Create()
        {
            _logger.LogInformation("Create method called.");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DebtDTO debtDto)
        {
            if (ModelState.IsValid)
            {
                var debt = _mapper.Map<Debt>(debtDto);
                await _debtService.AddDebtAsync(debt);
                _logger.LogInformation("Debt created successfully.");
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Model state is invalid.");
            return View(debtDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            _logger.LogInformation($"Edit method called for id: {id}");
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                _logger.LogWarning($"No debt found with id: {id}");
                return NotFound();
            }
            var debtDto = _mapper.Map<DebtDTO>(debt);
            return View(debtDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DebtDTO debtDto)
        {
            if (id != debtDto.Id)
            {
                _logger.LogWarning("Debt id mismatch.");
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var debt = _mapper.Map<Debt>(debtDto);
                await _debtService.UpdateDebtAsync(debt);
                _logger.LogInformation("Debt updated successfully.");
                return RedirectToAction(nameof(Index));
            }
            _logger.LogWarning("Model state is invalid.");
            return View(debtDto);
        }

        public async Task<IActionResult> Details(int id)
        {
            _logger.LogInformation($"Details method called for id: {id}");
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                _logger.LogWarning($"No debt found with id: {id}");
                return NotFound();
            }
            var debtDto = _mapper.Map<DebtDTO>(debt);
            return View(debtDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"Delete method called for id: {id}");
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                _logger.LogWarning($"No debt found with id: {id}");
                return NotFound();
            }
            var debtDto = _mapper.Map<DebtDTO>(debt);
            return View(debtDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _logger.LogInformation($"DeleteConfirmed method called for id: {id}");
            await _debtService.DeleteDebtAsync(id);
            _logger.LogInformation("Debt deleted successfully.");
            return RedirectToAction(nameof(Index));
        }
    }
}
