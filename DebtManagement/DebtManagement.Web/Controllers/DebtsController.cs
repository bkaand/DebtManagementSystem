/*using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DebtManagement.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DebtManagement.Web.Entities.Enums;

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
            DebtsViewModel viewModel = new DebtsViewModel
            {
                CreditCardDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetAllDebtsByTypeAsync(DebtType.CreditCard)),
                LoanDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetAllDebtsByTypeAsync(DebtType.Loan)),
                AvansDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetAllDebtsByTypeAsync(DebtType.Avans)),
                MonthlyRentsDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetAllDebtsByTypeAsync(DebtType.MonthlyRents)),
                OtherDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetAllDebtsByTypeAsync(DebtType.Other))
            };

            viewModel.IsEmpty = !viewModel.CreditCardDebts.Any() &&
                                !viewModel.LoanDebts.Any() &&
                                !viewModel.AvansDebts.Any() &&
                                !viewModel.MonthlyRentsDebts.Any() &&
                                !viewModel.OtherDebts.Any();

            return View(viewModel);
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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DebtManagement.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DebtManagement.Web.Entities.Enums;
using DebtManagement.Web.Repositories;


namespace DebtManagement.Web.Controllers
{
    public class DebtsController : Controller
    {
        private readonly IDebtService _debtService;
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public DebtsController(
            IDebtService debtService,
            IClientService clientService,
            IMapper mapper,
            UserManager<User> userManager)
        {
            _debtService = debtService;
            _clientService = clientService;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<IActionResult> Index()
        {
            // Get the current user's ID
            var userId = _userManager.GetUserId(User);

            // Fetch debts related to the logged-in user
            DebtsViewModel viewModel = new DebtsViewModel
            {
                CreditCardDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetDebtsByUserIdAndTypeAsync(userId, DebtType.CreditCard)),
                LoanDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetDebtsByUserIdAndTypeAsync(userId, DebtType.Loan)),
                AvansDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetDebtsByUserIdAndTypeAsync(userId, DebtType.Avans)),
                MonthlyRentsDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetDebtsByUserIdAndTypeAsync(userId, DebtType.MonthlyRents)),
                OtherDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetDebtsByUserIdAndTypeAsync(userId, DebtType.Other))
            };

            viewModel.IsEmpty = !viewModel.CreditCardDebts.Any() &&
                                !viewModel.LoanDebts.Any() &&
                                !viewModel.AvansDebts.Any() &&
                                !viewModel.MonthlyRentsDebts.Any() &&
                                !viewModel.OtherDebts.Any();

            return View(viewModel);
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
                debt.ClientId = _userManager.GetUserId(User); // Set the ClientId to the current user's ID
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
                debt.ClientId = _userManager.GetUserId(User); // Ensure the ClientId is the current user's ID
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
