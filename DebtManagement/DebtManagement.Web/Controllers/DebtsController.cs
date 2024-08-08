/*using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DebtManagement.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Controllers
{
    public class DebtsController : Controller
    {
        private readonly IDebtService _debtService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public DebtsController(IDebtService debtService, IClientService clientService, IMapper mapper)
        {
            _debtService = debtService;
            _clientService = clientService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var debts = await _debtService.GetAllDebtsAsync();
            var debtDtos = _mapper.Map<IEnumerable<DebtDTO>>(debts);
            return View(debtDtos);
        }

        public async Task<IActionResult> Create()
        {
            var clients = await _clientService.GetAllClientsAsync();
            ViewBag.Clients = new SelectList(clients, "Id", "Name");
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

            var clients = await _clientService.GetAllClientsAsync();
            ViewBag.Clients = new SelectList(clients, "Id", "Name");

            return View(debtDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                return NotFound();
            }

            var clients = await _clientService.GetAllClientsAsync();
            ViewBag.Clients = new SelectList(clients, "Id", "Name");

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

            var clients = await _clientService.GetAllClientsAsync();
            ViewBag.Clients = new SelectList(clients, "Id", "Name");

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
using Microsoft.AspNetCore.Mvc.Rendering;
using DebtManagement.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Controllers
{
    public class DebtsController : Controller
    {
        private readonly IDebtService _debtService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public DebtsController(IDebtService debtService, IClientService clientService, IMapper mapper)
        {
            _debtService = debtService;
            _clientService = clientService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var debts = await _debtService.GetAllDebtsAsync();
            var debtDtos = _mapper.Map<IEnumerable<DebtDTO>>(debts);
            return View(debtDtos);
        }

        public async Task<IActionResult> Create()
        {
            var clients = await _clientService.GetAllClientsAsync();
            ViewBag.Clients = new SelectList(clients, "Id", "Name");
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

            var clients = await _clientService.GetAllClientsAsync();
            ViewBag.Clients = new SelectList(clients, "Id", "Name");

            return View(debtDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var debt = await _debtService.GetDebtByIdAsync(id);
            if (debt == null)
            {
                return NotFound();
            }

            var clients = await _clientService.GetAllClientsAsync();
            ViewBag.Clients = new SelectList(clients, "Id", "Name");

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

            var clients = await _clientService.GetAllClientsAsync();
            ViewBag.Clients = new SelectList(clients, "Id", "Name");

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
