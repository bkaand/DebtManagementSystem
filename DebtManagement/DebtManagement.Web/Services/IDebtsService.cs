using DebtManagement.Web.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public interface IDebtsService
    {
        Task<IEnumerable<DebtDTO>> GetAllDebtsAsync();
    }
}
