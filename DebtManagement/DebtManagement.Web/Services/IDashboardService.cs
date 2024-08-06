using System.Threading.Tasks;
using DebtManagement.Web.DTOs;

namespace DebtManagement.Web.Services
{
    public interface IDashboardService
    {
        Task<int> GetTotalUsersAsync();
        Task<int> GetTotalClientsAsync();
        Task<int> GetTotalDebtsAsync();
        Task<int> GetTotalPaymentsAsync();
        Task<int> GetTotalIncomesAsync();
        Task<DashboardDataDto> GetDashboardDataAsync();
    }
}
