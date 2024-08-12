using AutoMapper;
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
