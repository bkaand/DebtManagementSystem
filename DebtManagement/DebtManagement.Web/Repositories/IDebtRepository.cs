using DebtManagement.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Repositories
{
    public interface IDebtRepository
    {
        Task<IEnumerable<Debt>> GetAllDebtsAsync();
        Task<Debt> GetDebtByIdAsync(int debtId);
        Task AddDebtAsync(Debt debt);
        Task UpdateDebtAsync(Debt debt);
        Task DeleteDebtAsync(int debtId);
    }
}
