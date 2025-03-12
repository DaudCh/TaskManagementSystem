using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskI.Core.DTOS.Notification;

namespace TaskI.Core.Service
{
    public interface INotificationService
    {
        // ✅ Basic CRUD Operations using DTOs
        Task AddNotificationAsync(NotificationCreateDTO notificationCreateDTO, CancellationToken cancellationToken = default);
        Task UpdateNotificationAsync(NotificationUpdateDTO notificationUpdateDTO, CancellationToken cancellationToken = default);
        Task<NotificationDTO> GetNotificationByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<NotificationDTO>> GetAllNotificationsAsync(CancellationToken cancellationToken = default);
        Task DeleteNotificationAsync(NotificationDeleteDTO notificationDeleteDTO, CancellationToken cancellationToken = default);

        Task<List<NotificationDTO>> GetNotificationsByUserIdAsync(int userId, CancellationToken cancellationToken = default);

       
        Task<List<NotificationDTO>> GetUnreadNotificationsAsync(int userId, CancellationToken cancellationToken = default);

 
        Task MarkAsReadAsync(NotificationReadDTO notificationReadDTO, CancellationToken cancellationToken = default);

     
        Task MarkAllAsReadAsync(int userId, CancellationToken cancellationToken = default);

        
        Task<List<NotificationDTO>> GetNotificationsByTypeAsync(string type, CancellationToken cancellationToken = default);

        
        Task DeleteOldNotificationsAsync(int days, CancellationToken cancellationToken = default);

       
        Task SendNotificationAsync(NotificationCreateDTO notificationCreateDTO, CancellationToken cancellationToken = default);
    }
}
