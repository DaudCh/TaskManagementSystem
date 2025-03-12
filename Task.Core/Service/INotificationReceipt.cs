using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskI.Core.DTOS.NotificationRecipient;

namespace TaskI.Core.Service
{
    public interface INotificationRecipientService
    {
        
        Task AddNotificationRecipientAsync(NotificationRecipientCreateDTO recipientCreateDTO, CancellationToken cancellationToken = default);
        Task UpdateNotificationRecipientAsync(NotificationRecipientUpdateDTO recipientUpdateDTO, CancellationToken cancellationToken = default);
        Task<NotificationRecipientDTO> GetNotificationRecipientByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<NotificationRecipientDTO>> GetAllNotificationRecipientsAsync(CancellationToken cancellationToken = default);
        Task DeleteNotificationRecipientAsync(NotificationRecipientDeleteDTO recipientDeleteDTO, CancellationToken cancellationToken = default);

     
        Task<List<NotificationRecipientDTO>> GetRecipientsByNotificationIdAsync(int notificationId, CancellationToken cancellationToken = default);

     
        Task<List<NotificationRecipientDTO>> GetNotificationsForUserAsync(int userId, CancellationToken cancellationToken = default);

       
        Task MarkNotificationAsReadAsync(int recipientId, CancellationToken cancellationToken = default);

        Task MarkAllNotificationsAsReadForUserAsync(int userId, CancellationToken cancellationToken = default);
    }
}
