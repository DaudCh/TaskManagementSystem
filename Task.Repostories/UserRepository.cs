using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskI.Core.Entities;
using TaskI.Core.Repository;

namespace TaskI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Add a new User
        public async ValueTask AddUserAsync(User user, CancellationToken cancellationToken = default)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // ✅ Update User details
        public async ValueTask UpdateUserAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // ✅ Get User by ID
        public async Task<User> GetUserByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FindAsync(new object[] { id }, cancellationToken);
        }

        // ✅ Get All Users
        public async Task<List<User>> GetAllUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Users.ToListAsync(cancellationToken);
        }

        // ✅ Delete User by ID
        public async ValueTask DeleteUserAsync(int id, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        // ✅ Authenticate User (Login)
        public async Task<User> AuthenticateUserAsync(string email, string password, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password, cancellationToken);
        }

        // ✅ Get Users by Role
        public async Task<List<User>> GetUsersByRoleAsync(string role, CancellationToken cancellationToken = default)
        {
            return await _context.Users
                .Where(u => u.Role == role)
                .ToListAsync(cancellationToken);
        }
    }
}
