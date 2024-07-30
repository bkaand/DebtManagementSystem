using DebtManagement.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<User>> GetAllClientsAsync();
        Task<User> GetClientByIdAsync(string clientId);
        Task AddClientAsync(User client);
        Task UpdateClientAsync(User client);
        Task DeleteClientAsync(string clientId);
    }
}
