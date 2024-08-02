using DebtManagement.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Repositories
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<Payment> GetByIdAsync(int id);
        Task AddAsync(Payment payment);
        Task UpdateAsync(Payment payment);
        Task DeleteAsync(int id);
    }
}
