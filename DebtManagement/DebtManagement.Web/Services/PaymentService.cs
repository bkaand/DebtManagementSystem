
/*using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDTO>>(payments);
        }

        public async Task<PaymentDTO> GetPaymentByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task AddPaymentAsync(PaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _paymentRepository.AddAsync(payment);
        }

        public async Task UpdatePaymentAsync(PaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _paymentRepository.UpdateAsync(payment);
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _paymentRepository.DeleteAsync(id);
        }
    }
}
*/
using AutoMapper;
using DebtManagement.Web.DTOs;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync()
        {
            var payments = await _paymentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentDTO>>(payments);
        }

        public async Task<PaymentDTO> GetPaymentByIdAsync(int id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentDTO>(payment);
        }

        public async Task AddPaymentAsync(PaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _paymentRepository.AddAsync(payment);
        }

        public async Task UpdatePaymentAsync(PaymentDTO paymentDto)
        {
            var payment = _mapper.Map<Payment>(paymentDto);
            await _paymentRepository.UpdateAsync(payment);
        }

        public async Task DeletePaymentAsync(int id)
        {
            await _paymentRepository.DeleteAsync(id);
        }
    }
}
