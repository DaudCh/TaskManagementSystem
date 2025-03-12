using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TaskI.Core.DTOS.Notification;
using TaskI.Core.Entities;
using TaskI.Core.Repository;
using TaskI.Core.Services;

namespace TaskI.Services
{
    public class NotificationService : INotification
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationRecipientRepository _recipientRepository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository notificationRepository, INotificationRecipientRepository recipientRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _recipientRepository = recipientRepository;
            _mapper = mapper;
        }

        // ✅ Add Notification & Assign Recipients
        public async ValueTask AddNotificationAsync(NotificationCreateDTO notificationDto, CancellationToken cancellationToken = default)
        {
            if (notificationDto == null)
                throw new ArgumentNullException(nameof(notificationDto));

            var notification = _mapper.Map<Notification>(notificationDto);
            await _notificationRepository.AddNotificationAsync(notification, cancellationToken);

            // Assign notification to recipients
            if (notificationDto.RecipientUserIds != null && notificationDto.RecipientUserIds.Any())
            {
                var recipients = notificationDto.RecipientUserIds.Select(userId => new NotificationRecipient
                {
                    NotificationId = notification.Id,
                    UserId = userId,
                    IsRead = false
                }).ToList();

                foreach (var recipient in recipients)
                {
                    await _recipientRepository.AddNotificationRecipientAsync(recipient, cancellationToken);
                }
            }
        }

        // ✅ Get Notification by ID
        public async Task<NotificationDTO> GetNotificationByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(id);
            return _mapper.Map<NotificationDTO>(notification);
        }

        // ✅ Get All Notifications
        public async Task<List<NotificationDTO>> GetAllNotificationsAsync(CancellationToken cancellationToken = default)
        {
            var notifications = await _notificationRepository.GetAllNotificationsAsync();
            return _mapper.Map<List<NotificationDTO>>(notifications);
        }

        // ✅ Update Notification
        public async ValueTask UpdateNotificationAsync(NotificationUpdateDTO notificationDto, CancellationToken cancellationToken = default)
        {
            var notification = await _notificationRepository.GetNotificationByIdAsync(notificationDto.Id);
            if (notification == null)
                throw new KeyNotFoundException($"Notification with ID {notificationDto.Id} not found.");

            _mapper.Map(notificationDto, notification);
            await _notificationRepository.UpdateNotificationAsync(notification, cancellationToken);
        }

        // ✅ Delete Notification
        public async ValueTask DeleteNotificationAsync(int id, CancellationToken cancellationToken = default)
        {
            await _notificationRepository.DeleteNotificationAsync(id, cancellationToken);
        }

        // ✅ Get Notifications for a User
        public async Task<List<NotificationDTO>> GetNotificationsByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var notifications = await _notificationRepository.GetNotificationsByUserIdAsync(userId, cancellationToken);
            return _mapper.Map<List<NotificationDTO>>(notifications);
        }

        // ✅ Get Notifications by Type
        public async Task<List<NotificationDTO>> GetNotificationsByTypeAsync(string type, CancellationToken cancellationToken = default)
        {
            var notifications = await _notificationRepository.GetNotificationsByTypeAsync(type, cancellationToken);
            return _mapper.Map<List<NotificationDTO>>(notifications);
        }

        // ✅ Mark Notification as Read
        public async ValueTask MarkNotificationAsReadAsync(NotificationReadDTO notificationReadDto, CancellationToken cancellationToken = default)
        {
            var recipient = await _recipientRepository.GetRecipientByNotificationAndUserIdAsync(notificationReadDto.NotificationId, notificationReadDto.UserId, cancellationToken);
            if (recipient == null)
                throw new KeyNotFoundException("Notification recipient not found.");

            recipient.IsRead = true;
            await _recipientRepository.UpdateNotificationRecipientAsync(recipient, cancellationToken);
        }

        // ✅ Mark All Notifications as Read for a User
        public async ValueTask MarkAllNotificationsAsReadForUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            await _recipientRepository.MarkAllNotificationsAsReadForUserAsync(userId, cancellationToken);
        }
    }
}