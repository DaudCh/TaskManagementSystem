using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskI.Core.Entities;

namespace TaskI.Core.Repository
{
    public interface INotificationRecipientRepository
    {
       
        ValueTask AddNotificationRecipientAsync(NotificationRecipient notificationRecipient, CancellationToken cancellationToken = default);
        ValueTask UpdateNotificationRecipientAsync(NotificationRecipient notificationRecipient, CancellationToken cancellationToken = default);
        Task<NotificationRecipient> GetNotificationRecipientByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<NotificationRecipient>> GetAllNotificationRecipientsAsync(CancellationToken cancellationToken = default);
        ValueTask DeleteNotificationRecipientAsync(int id, CancellationToken cancellationToken = default);

        
        Task<List<NotificationRecipient>> GetRecipientsByNotificationIdAsync(int notificationId, CancellationToken cancellationToken = default);

        
        Task<List<NotificationRecipient>> GetNotificationsForUserAsync(int userId, CancellationToken cancellationToken = default);

        ValueTask MarkNotificationAsReadAsync(int recipientId, CancellationToken cancellationToken = default);

        
        ValueTask MarkAllNotificationsAsReadForUserAsync(int userId, CancellationToken cancellationToken = default);
    }
}
