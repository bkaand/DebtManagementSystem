using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtManagement.Web.Entities;

namespace DebtManagement.Web.Controllers
{
    [Authorize]
    public class CalculatorController : Controller
    {
        private readonly IDebtService _debtService;
        private readonly IIncomeService _incomeService;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CalculatorController(
            IDebtService debtService, 
            IIncomeService incomeService, 
            IPaymentService paymentService, 
            IMapper mapper,
            UserManager<User> userManager)
        {
            _debtService = debtService;
            _incomeService = incomeService;
            _paymentService = paymentService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user?.Id;
            
            var viewModel = new CalculatorViewModel();

            // Get data from services filtered by user
            var debts = await _debtService.GetDebtsByClientIdAsync(userId);
            var incomes = await _incomeService.GetIncomesByClientIdAsync(userId);
            var payments = await _paymentService.GetPaymentsByClientIdAsync(userId);
            
            // Calculate totals
            var totalDebts = debts.Sum(d => d.DebtAmount);
            var totalIncome = incomes.Sum(i => i.MonthlyIncome);
            
            viewModel.TotalDebts = totalDebts;
            viewModel.TotalIncomes = totalIncome;

            // Populate Debt and Income distribution data
            var debtTypes = debts.GroupBy(d => d.DebtType)
                                 .Select(g => new { DebtType = g.Key, Total = g.Sum(d => d.DebtAmount) })
                                 .ToList();

            viewModel.DebtLabels = debtTypes.Select(d => d.DebtType.ToString()).ToList();
            viewModel.DebtValues = debtTypes.Select(d => d.Total).ToList();

            var incomeSources = incomes.GroupBy(i => i.AdditionalIncomeSources)
                                       .Select(g => new { Source = g.Key ?? "Primary", Total = g.Sum(i => i.MonthlyIncome) })
                                       .ToList();

            viewModel.IncomeLabels = incomeSources.Select(i => i.Source).ToList();
            viewModel.IncomeValues = incomeSources.Select(i => i.Total).ToList();

            // Calculate and populate monthly totals for comparison
            viewModel.MonthLabels = debts.Select(d => d.CreateDate.ToString("yyyy-MM"))
                                         .Distinct()
                                         .ToList();

            viewModel.MonthlyDebtValues = debts.GroupBy(d => d.CreateDate.ToString("yyyy-MM"))
                                               .Select(g => g.Sum(d => d.DebtAmount))
                                               .ToList();

            viewModel.MonthlyIncomeValues = incomes.GroupBy(i => i.RecordedDate.ToString("yyyy-MM"))
                                                   .Select(g => g.Sum(i => i.MonthlyIncome))
                                                   .ToList();

            return View(viewModel);
        }
    }
}
