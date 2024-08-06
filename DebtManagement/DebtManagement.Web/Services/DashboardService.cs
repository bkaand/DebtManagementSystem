using DebtManagement.Web.Data;
using DebtManagement.Web.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalUsersAsync()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<int> GetTotalClientsAsync()
        {
            return await _context.Clients.CountAsync();
        }

        public async Task<int> GetTotalDebtsAsync()
        {
            return await _context.Debts.CountAsync();
        }

        public async Task<int> GetTotalPaymentsAsync()
        {
            return await _context.Payments.CountAsync();
        }

        public async Task<int> GetTotalIncomesAsync()
        {
            return await _context.Incomes.CountAsync();
        }

        public async Task<DashboardDataDto> GetDashboardDataAsync()
        {
            var dashboardData = new DashboardDataDto
            {
                TotalUsers = await GetTotalUsersAsync(),
                TotalClients = await GetTotalClientsAsync(),
                TotalDebts = await GetTotalDebtsAsync(),
                TotalPayments = await GetTotalPaymentsAsync(),
                TotalIncomes = await GetTotalIncomesAsync()
            };

            return dashboardData;
        }
    }
}
