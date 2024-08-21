using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public PaymentController(IPaymentService paymentService, IMapper mapper, UserManager<User> userManager)
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var payments = await _paymentService.GetPaymentsByClientIdAsync(userId);
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
                var userId = _userManager.GetUserId(User);
                paymentDto.ClientId = userId;
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
                return BadRequest();
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
