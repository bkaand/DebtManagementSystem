using DebtManagement.Web.Entities;
using DebtManagement.Web.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public class DebtService : IDebtService
    {
        private readonly IDebtRepository _debtRepository;

        public DebtService(IDebtRepository debtRepository)
        {
            _debtRepository = debtRepository;
        }

        public async Task<IEnumerable<Debt>> GetAllDebtsAsync()
        {
            return await _debtRepository.GetAllDebtsAsync();
        }

        public async Task<Debt> GetDebtByIdAsync(int id)
        {
            return await _debtRepository.GetDebtByIdAsync(id);
        }

        public async Task AddDebtAsync(Debt debt)
        {
            await _debtRepository.AddDebtAsync(debt);
        }

        public async Task UpdateDebtAsync(Debt debt)
        {
            await _debtRepository.UpdateDebtAsync(debt);
        }

        public async Task DeleteDebtAsync(int id)
        {
            await _debtRepository.DeleteDebtAsync(id);
        }
    }
}
