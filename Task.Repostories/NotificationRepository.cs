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
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Add Notification
        public async ValueTask AddNotificationAsync(Notification notification, CancellationToken cancellationToken = default)
        {
            await _context.Notifications.AddAsync(notification, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // ✅ Update Notification
        public async ValueTask UpdateNotificationAsync(Notification notification, CancellationToken cancellationToken = default)
        {
            _context.Notifications.Update(notification);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // ✅ Get Notification by ID
        public async Task<Notification> GetNotificationByIdAsync(int id)
        {
            return await _context.Notifications.FindAsync(id);
        }

        // ✅ Get All Notifications
        public async Task<List<Notification>> GetAllNotificationsAsync()
        {
            return await _context.Notifications.ToListAsync();
        }

        // ✅ Delete Notification by ID
        public async ValueTask DeleteNotificationAsync(int id, CancellationToken cancellationToken = default)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        // ✅ Get Notifications by User ID
        public async Task<List<Notification>> GetNotificationsByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await _context.Notifications
                .Where(n => n.User.Id == userId)
                .OrderByDescending(n => n.CreatedBy)
                .ToListAsync(cancellationToken);
        }

       

    
        public async Task<List<Notification>> GetNotificationsByTypeAsync(string type, CancellationToken cancellationToken = default)
        {
            return await _context.Notifications
                .Where(n => n.Type == type)
                .OrderByDescending(n => n.CreatedBy)
                .ToListAsync(cancellationToken);
        }

    
    }
}
