using DebtManagement.Web.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DebtManagement.Web.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string userId);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string userId);
    }
}
