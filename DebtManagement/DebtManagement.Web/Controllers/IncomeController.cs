using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DebtManagement.Web.Entities;

namespace DebtManagement.Web.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public IncomeController(IIncomeService incomeService, IMapper mapper, UserManager<User> userManager)
        {
            _incomeService = incomeService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var incomes = await _incomeService.GetIncomesByClientIdAsync(userId);//kjwebfjwbfjhebwf userid or clientid
            var incomeDtos = _mapper.Map<IEnumerable<IncomeDto>>(incomes);
            return View(incomeDtos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var income = await _incomeService.GetIncomeByIdAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            var incomeDto = _mapper.Map<IncomeDto>(income);
            return View(incomeDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IncomeDto incomeDto)
        {
            if (ModelState.IsValid)
            {
                incomeDto.ClientId = _userManager.GetUserId(User); // Set the ClientId to the current user's ID
                await _incomeService.AddIncomeAsync(incomeDto);
                return RedirectToAction(nameof(Index));
            }
            return View(incomeDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var income = await _incomeService.GetIncomeByIdAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            var incomeDto = _mapper.Map<IncomeDto>(income);
            return View(incomeDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IncomeDto incomeDto)
        {
            if (id != incomeDto.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _incomeService.UpdateIncomeAsync(incomeDto);
                return RedirectToAction(nameof(Index));
            }
            return View(incomeDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var income = await _incomeService.GetIncomeByIdAsync(id);
            if (income == null)
            {
                return NotFound();
            }
            var incomeDto = _mapper.Map<IncomeDto>(income);
            return View(incomeDto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _incomeService.DeleteIncomeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
