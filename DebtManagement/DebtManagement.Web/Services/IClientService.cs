using DebtManagement.Web.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAllClientsAsync();
        Task<ClientDTO> GetClientByIdAsync(int id);
        Task AddClientAsync(ClientDTO client);
        Task UpdateClientAsync(ClientDTO client);
        Task DeleteClientAsync(int id);
    }
}
