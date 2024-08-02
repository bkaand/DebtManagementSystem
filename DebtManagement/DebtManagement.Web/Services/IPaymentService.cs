using DebtManagement.Web.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public interface IPaymentService
    {
        Task<IEnumerable<PaymentDTO>> GetAllPaymentsAsync();
        Task<PaymentDTO> GetPaymentByIdAsync(int id);
        Task AddPaymentAsync(PaymentDTO paymentDto);
        Task UpdatePaymentAsync(PaymentDTO paymentDto);
        Task DeletePaymentAsync(int id);
    }
}