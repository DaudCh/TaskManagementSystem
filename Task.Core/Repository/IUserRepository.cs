using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskI.Core.Entities;

namespace TaskI.Core.Repository
{
    public interface IUserRepository
    {
       
        ValueTask AddUserAsync(User user, CancellationToken cancellationToken = default);
        ValueTask UpdateUserAsync(User user, CancellationToken cancellationToken = default);
        Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default);
        ValueTask DeleteUserAsync(int id, CancellationToken cancellationToken = default);

        
        Task<User> AuthenticateUserAsync(string email, string password, CancellationToken cancellationToken = default);

      
        Task<List<User>> GetUsersByRoleAsync(string role, CancellationToken cancellationToken = default);
    }
}
