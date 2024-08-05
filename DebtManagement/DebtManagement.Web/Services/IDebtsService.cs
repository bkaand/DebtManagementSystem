using DebtManagement.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public interface IDebtService
    {
        Task<IEnumerable<Debt>> GetAllDebtsAsync();
        Task<Debt> GetDebtByIdAsync(int id);
        Task AddDebtAsync(Debt debt);
        Task UpdateDebtAsync(Debt debt);
        Task DeleteDebtAsync(int id);
    }
}
