using DebtManagement.Web.Data;
using DebtManagement.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DebtManagement.Web.Repositories
{
    public class DebtRepository : IDebtRepository
    {
        private readonly ApplicationDbContext _context;

        public DebtRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Debt>> GetAllDebtsAsync()
        {
            return await _context.Debts.ToListAsync();
        }

        public async Task<Debt> GetDebtByIdAsync(int debtId)
        {
            return await _context.Debts.FindAsync(debtId);
        }

        public async Task AddDebtAsync(Debt debt)
        {
            await _context.Debts.AddAsync(debt);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDebtAsync(Debt debt)
        {
            _context.Debts.Update(debt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDebtAsync(int debtId)
        {
            var debt = await _context.Debts.FindAsync(debtId);
            if (debt != null)
            {
                _context.Debts.Remove(debt);
                await _context.SaveChangesAsync();
            }
        }
    }
}
