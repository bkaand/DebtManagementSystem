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
            var debtDtos = _mapper.Map<IEnumerable<DebtDto>>(debts);
            return View(debtDtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DebtDto debtDto)
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
            var debtDto = _mapper.Map<DebtDto>(debt);
            return View(debtDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DebtDto debtDto)
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
            var debtDto = _mapper.Map<DebtDto>(debt);
            return View(debtDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                return NotFound();
            }
            var debtDto = _mapper.Map<DebtDto>(debt);
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
            var debtDtos = _mapper.Map<IEnumerable<DebtDto>>(debts);
            return View(debtDtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DebtDto debtDto)
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
            var debtDto = _mapper.Map<DebtDto>(debt);
            return View(debtDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DebtDto debtDto)
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
            var debtDto = _mapper.Map<DebtDto>(debt);
            return View(debtDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                return NotFound();
            }
            var debtDto = _mapper.Map<DebtDto>(debt);
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
