/*using AutoMapper;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace DebtManagement.Web.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly IDebtService _debtService;
        private readonly IClientService _clientService;


        private readonly IIncomeService _incomeService;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public CalculatorController(IClientService clientService)
        {
            _clientService = clientService;
        }


        public IActionResult Index()
        {


            return View();
        }
    }
}
*/
using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DebtManagement.Web.Controllers
{
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

            // Map data to DTOs
            viewModel.Debts = _mapper.Map<List<DebtDTO>>(debts);
            viewModel.Incomes = _mapper.Map<List<IncomeDto>>(incomes);
            viewModel.Payments = _mapper.Map<List<PaymentDTO>>(payments);

            // Calculate summary information
            viewModel.TotalDebt = viewModel.Debts.Sum(d => d.DebtAmount);
            viewModel.TotalIncome = viewModel.Incomes.Sum(i => i.MonthlyIncome);
            viewModel.TotalPayments = viewModel.Payments.Sum(p => p.AmountPaid);
            viewModel.NetBalance = viewModel.TotalIncome - viewModel.TotalDebt;

            // Populate Chart.js data
            viewModel.IncomeLabels = viewModel.Incomes.Select(i => i.Source).ToList();
            viewModel.IncomeValues = viewModel.Incomes.Select(i => i.MonthlyIncome).ToList();

            viewModel.DebtLabels = viewModel.Debts.Select(d => d.DebtType.ToString()).ToList();
            viewModel.DebtValues = viewModel.Debts.Select(d => d.DebtAmount).ToList();

            viewModel.PaymentLabels = viewModel.Payments.Select(p => p.PaymentDate.ToString("MM/yyyy")).ToList();
            viewModel.PaymentValues = viewModel.Payments.Select(p => p.AmountPaid).ToList();

            return View(viewModel);
        }
    }
}
