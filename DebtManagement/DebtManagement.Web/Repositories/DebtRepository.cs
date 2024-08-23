using DebtManagement.Web.Data;
using DebtManagement.Web.Entities;
using DebtManagement.Web.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<Debt>> GetAllDebtsByTypeAsync(DebtType type)
        {
            return await _context.Debts.Where(d => d.DebtType == type).ToListAsync();
        }

        public async Task<IEnumerable<Debt>> GetDebtsByClientIdAndTypeAsync(string clientId, DebtType type)
        {
            return await _context.Debts.Where(d => d.ClientId == clientId && d.DebtType == type).ToListAsync();
        }

        public async Task<IEnumerable<Debt>> GetDebtsByClientId(string clientId)
        {
            return await _context.Debts.Where(d => d.ClientId == clientId).ToListAsync();
        }

        public async Task<Debt> GetDebtByIdAsync(int debtId)
        {
            return await _context.Debts.FindAsync(debtId);
        }

        public async Task AddDebtAsync(Debt debt)
        {
            try
            {
                await _context.Debts.AddAsync(debt);
                await _context.SaveChangesAsync();
                System.Diagnostics.Debug.WriteLine("Debt added successfully.");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error adding debt: {ex.Message}");
                throw;  // Rethrow the exception after logging
            }
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
