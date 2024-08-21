using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DebtManagement.Web.Controllers
{
    [Authorize]
    public class CalculatorController : Controller
    {
        private readonly IDebtService _debtService;
        private readonly IIncomeService _incomeService;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public CalculatorController(IDebtService debtService, IIncomeService incomeService, IPaymentService paymentService, IMapper mapper)
        {
            _debtService = debtService;
            _incomeService = incomeService;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CalculatorViewModel();

            // Get data from services
            var debts = await _debtService.GetAllDebtsAsync();
            var incomes = await _incomeService.GetAllIncomesAsync();
            var payments = await _paymentService.GetAllPaymentsAsync();
            
            
            var totalDebts= debts.Sum(d => d.DebtAmount);// use them for total debt vs income
            var TotalIncome = incomes.Sum(i => i.MonthlyIncome);//same 
            viewModel.TotalDebts = totalDebts;
            viewModel.TotalIncomes = TotalIncome;
            // debtAmount/intsallements
            var monthlyDebts = debts.Select(x => x.DebtAmount);


            // Map data to DTOs
            List<DebtDTO> debtList = _mapper.Map<List<DebtDTO>>(debts);
            decimal thisMonthDebt = 0;
         
            foreach(var debt in debtList) 
            {
                //kredi taksitli oluyor, Açık hesap 100% ödeniyor, kira 100% ödeniyor, Credit Card 100% ödeniyor, diğerleri 50% ödeniyor
                //installment amount hesaplaması
                if (debt.Installments > 0)
                {
                    debt.InstallmentAmount = debt.DebtAmount / debt.Installments;
                }
                else
                {
                    debt.InstallmentAmount = 0; // or handle it in a way that makes sense for your application
                }

                //thisMonthDebt hesaplaması


            }
            //
            var incomess = _mapper.Map<List<IncomeDto>>(incomes);
            var paymentss = _mapper.Map<List<PaymentDTO>>(payments);

            // Populate Chart.js data
            viewModel.IncomeLabels = incomess.Select(i => i.Source).ToList();
            viewModel.IncomeValues = incomess.Select(i => i.MonthlyIncome).ToList();

            viewModel.DebtLabels = debtList.Select(d => d.DebtType.ToString()).ToList();
            viewModel.DebtValues = debtList.Select(d => d.DebtAmount).ToList();

            viewModel.PaymentLabels = paymentss.Select(p => p.PaymentDate.ToString("MM/yyyy")).ToList();
            viewModel.PaymentValues = paymentss.Select(p => p.AmountPaid).ToList();

            return View(viewModel);
        }
    }
}
//total income vs total debt