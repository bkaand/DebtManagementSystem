using DebtManagement.Web.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public interface IIncomeService
    {
        Task<IEnumerable<IncomeDto>> GetAllIncomesAsync();
        Task<IEnumerable<IncomeDto>> GetIncomesByClientIdAsync(string clientId); 
        Task<IncomeDto> GetIncomeByIdAsync(int incomeId);
        Task AddIncomeAsync(IncomeDto incomeDto);
        Task UpdateIncomeAsync(IncomeDto incomeDto);
        Task DeleteIncomeAsync(int incomeId);
    }
}