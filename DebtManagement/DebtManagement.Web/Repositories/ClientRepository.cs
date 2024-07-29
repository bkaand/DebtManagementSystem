using DebtManagement.Web.Data;
using DebtManagement.Web.Models;

namespace DebtManagement.Web.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Implement any additional methods specific to Client entity here
    }
}
