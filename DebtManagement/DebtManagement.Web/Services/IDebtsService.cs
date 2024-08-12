using DebtManagement.Web.Entities;
using DebtManagement.Web.Entities.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public interface IDebtService
    {
        Task<IEnumerable<Debt>> GetAllDebtsAsync();
        Task<IEnumerable<Debt>> GetAllDebtsByTypeAsync(DebtType type);
        Task<Debt> GetDebtByIdAsync(int id);
        Task AddDebtAsync(Debt debt);
        Task UpdateDebtAsync(Debt debt);
        Task DeleteDebtAsync(int id);
    }
}
