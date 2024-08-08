/*using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return View(payments);
        }

        public async Task<IActionResult> Details(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentDTO paymentDto)
        {
            if (ModelState.IsValid)
            {
                await _paymentService.AddPaymentAsync(paymentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentDTO paymentDto)
        {
            if (id != paymentDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _paymentService.UpdatePaymentAsync(paymentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paymentService.DeletePaymentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
*/

using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            var paymentDtos = _mapper.Map<IEnumerable<PaymentDTO>>(payments);
            return View(paymentDtos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDto = _mapper.Map<PaymentDTO>(payment);
            return View(paymentDto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentDTO paymentDto)
        {
            if (ModelState.IsValid)
            {
                var paymentMapped = _mapper.Map<Payment>(paymentDto);
                var paymentDtoMapped = _mapper.Map<PaymentDTO>(paymentMapped);
                await _paymentService.AddPaymentAsync(paymentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDto = _mapper.Map<PaymentDTO>(payment);
            return View(paymentDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PaymentDTO paymentDto)
        {
            if (id != paymentDto.Id)
            {
                return NotFound();
            }
        
            if (ModelState.IsValid)
            {
                await _paymentService.UpdatePaymentAsync(paymentDto);
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
            {
                return NotFound();
            }
            var paymentDto = _mapper.Map<PaymentDTO>(payment);
            return View(paymentDto);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _paymentService.DeletePaymentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
