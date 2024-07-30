using DebtManagement.Web.Entities;
using DebtManagement.Web.Repositories;

namespace DebtManagement.Web.Services
{
    public class DebtsService
    {

        private readonly IDebtRepository _debtRepository;

        public DebtsService(IDebtRepository debtRepository)
        {
            _debtRepository = debtRepository;
        }


        public async Task<IEnumerable<Debt>> GetAllDebtsAsync() 
        { 
            var debts = await _debtRepository.GetAllDebtsAsync();

            return debts;
        }
    }
}
