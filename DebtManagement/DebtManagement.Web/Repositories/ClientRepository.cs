using DebtManagement.Web.Data;
using DebtManagement.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllClientsAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetClientByIdAsync(string clientId)
        {
            return await _context.Users.FindAsync(clientId);
        }

        public async Task AddClientAsync(User client)
        {
            await _context.Users.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(User client)
        {
            _context.Users.Update(client);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientAsync(string clientId)
        {
            var client = await _context.Users.FindAsync(clientId);
            if (client != null)
            {
                _context.Users.Remove(client);
                await _context.SaveChangesAsync();
            }
        }
    }
}
