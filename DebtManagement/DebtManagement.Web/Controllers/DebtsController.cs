/* This one works, also dont forget to remove ClientId from add and edit?. Auto fill it with the current ClientId. Same applies with payment and income and graph. Also installments are wrong.*/
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
            var userId = _userManager.GetUserId(User);

            DebtsViewModel viewModel = new DebtsViewModel
            {
                CreditCardDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetDebtsByClientIdAndTypeAsync(userId, DebtType.CreditCard)),
                LoanDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetDebtsByClientIdAndTypeAsync(userId, DebtType.Loan)),
                AvansDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetDebtsByClientIdAndTypeAsync(userId, DebtType.Avans)),
                MonthlyRentsDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetDebtsByClientIdAndTypeAsync(userId, DebtType.MonthlyRents)),
                OtherDebts = _mapper.Map<List<DebtDTO>>(await _debtService.GetDebtsByClientIdAndTypeAsync(userId, DebtType.Other))
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
                debt.ClientId = _userManager.GetUserId(User); 
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
                debt.ClientId = _userManager.GetUserId(User); 
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
