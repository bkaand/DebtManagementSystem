using DebtManagement.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Repositories
{
    public interface IIncomeRepository
    {
        Task<IEnumerable<Income>> GetAllIncomesAsync();
        Task<Income> GetIncomeByIdAsync(int incomeId);
        Task AddIncomeAsync(Income income);
        Task UpdateIncomeAsync(Income income);
        Task DeleteIncomeAsync(int incomeId);
    }
}
