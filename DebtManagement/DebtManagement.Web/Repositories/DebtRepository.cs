using DebtManagement.Web.Data;
using DebtManagement.Web.Entities;
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
            var fakeDebts = new List<Debt>
    {
        new Debt { Id = 1, DebtAmount = 1000, DebtType = "Kredi" , CreateDate = DateTime.Now, ClientId="1", },
        new Debt { Id = 2, DebtAmount = 2000, DebtType = "Kredi Kart" , CreateDate = DateTime.Now, ClientId="1", },
        new Debt { Id = 3, DebtAmount = 3000, DebtType = "Avans hesap" , CreateDate = DateTime.Now, ClientId="1", },
        new Debt { Id = 4, DebtAmount = 4000, DebtType = "Borc" , CreateDate = DateTime.Now, ClientId="1", },

    };

            return await Task.FromResult(fakeDebts);
        }

        //public async Task<IEnumerable<Debt>> GetAllDebtsAsync()
        //{
        //    return await _context.Debts.ToListAsync();
        //}


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
