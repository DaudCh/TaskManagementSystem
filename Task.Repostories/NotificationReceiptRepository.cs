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
    public class NotificationRecipientRepository : INotificationRecipientRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRecipientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Add Notification Recipient
        public async ValueTask AddNotificationRecipientAsync(NotificationRecipient notificationRecipient, CancellationToken cancellationToken = default)
        {
            await _context.NotificationRecipients.AddAsync(notificationRecipient, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // ✅ Update Notification Recipient
        public async ValueTask UpdateNotificationRecipientAsync(NotificationRecipient notificationRecipient, CancellationToken cancellationToken = default)
        {
            _context.NotificationRecipients.Update(notificationRecipient);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // ✅ Get Notification Recipient by ID
        public async Task<NotificationRecipient> GetNotificationRecipientByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.NotificationRecipients.FindAsync(new object[] { id }, cancellationToken);
        }

        // ✅ Get All Notification Recipients
        public async Task<List<NotificationRecipient>> GetAllNotificationRecipientsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.NotificationRecipients.ToListAsync(cancellationToken);
        }

        // ✅ Delete Notification Recipient
        public async ValueTask DeleteNotificationRecipientAsync(int id, CancellationToken cancellationToken = default)
        {
            var recipient = await _context.NotificationRecipients.FindAsync(id);
            if (recipient != null)
            {
                _context.NotificationRecipients.Remove(recipient);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        // ✅ Get Recipients by Notification ID
        public async Task<List<NotificationRecipient>> GetRecipientsByNotificationIdAsync(int notificationId, CancellationToken cancellationToken = default)
        {
            return await _context.NotificationRecipients
                .Where(nr => nr.NotificationId == notificationId)
                .ToListAsync(cancellationToken);
        }

        // ✅ Get Notifications for a User
        public async Task<List<NotificationRecipient>> GetNotificationsForUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await _context.NotificationRecipients
                .Where(nr => nr.UserId == userId)
                .Include(nr => nr.Notification)  // Include Notification details
                .ToListAsync(cancellationToken);
        }

        // ✅ Mark a Single Notification as Read
        public async ValueTask MarkNotificationAsReadAsync(int recipientId, CancellationToken cancellationToken = default)
        {
            var recipient = await _context.NotificationRecipients.FindAsync(recipientId);
            if (recipient != null)
            {
                recipient.Status = "Read";
                _context.NotificationRecipients.Update(recipient);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        // ✅ Mark All Notifications as Read for a User
        public async ValueTask MarkAllNotificationsAsReadForUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            var recipients = await _context.NotificationRecipients
                .Where(nr => nr.UserId == userId && nr.Status != "Read")
                .ToListAsync(cancellationToken);

            if (recipients.Any())
            {
                foreach (var recipient in recipients)
                {
                    recipient.Status = "Read";
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
