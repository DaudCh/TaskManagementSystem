using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskI.Core.Entities;

namespace TaskI.Core.Repository
{
    public interface INotificationRepository
    {
       
        ValueTask AddNotificationAsync(Notification notification, CancellationToken cancellationToken = default);
        ValueTask UpdateNotificationAsync(Notification notification, CancellationToken cancellationToken = default);
        Task<Notification> GetNotificationByIdAsync(int id);
        Task<List<Notification>> GetAllNotificationsAsync();
        ValueTask DeleteNotificationAsync(int id, CancellationToken cancellationToken = default);

        Task<List<Notification>> GetNotificationsByUserIdAsync(int userId, CancellationToken cancellationToken = default);

       

        
        Task<List<Notification>> GetNotificationsByTypeAsync(string type, CancellationToken cancellationToken = default);

   
        
    }
}
