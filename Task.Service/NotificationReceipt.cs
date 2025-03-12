using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TaskI.Core.DTOS.NotificationRecipient;
using TaskI.Core.Entities;
using TaskI.Core.Repository;
using TaskI.Core.Services;

namespace TaskI.Services
{
    public class NotificationRecipientService : INotificationRecipientService
    {
        private readonly INotificationRecipientRepository _notificationRecipientRepository;
        private readonly IMapper _mapper;

        public NotificationRecipientService(INotificationRecipientRepository notificationRecipientRepository, IMapper mapper)
        {
            _notificationRecipientRepository = notificationRecipientRepository;
            _mapper = mapper;
        }

        // ✅ Add Notification Recipient
        public async ValueTask AddNotificationRecipientAsync(NotificationRecipientCreateDTO recipientDto, CancellationToken cancellationToken = default)
        {
            if (recipientDto == null)
            {
                throw new ArgumentNullException(nameof(recipientDto), "Recipient data cannot be null.");
            }

            var recipient = _mapper.Map<NotificationRecipient>(recipientDto);
            await _notificationRecipientRepository.AddNotificationRecipientAsync(recipient, cancellationToken);
        }

        // ✅ Get Notification Recipient by ID
        public async Task<NotificationRecipientDTO> GetNotificationRecipientByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var recipient = await _notificationRecipientRepository.GetNotificationRecipientByIdAsync(id, cancellationToken);
            return _mapper.Map<NotificationRecipientDTO>(recipient);
        }

        // ✅ Get All Notification Recipients
        public async Task<List<NotificationRecipientDTO>> GetAllNotificationRecipientsAsync(CancellationToken cancellationToken = default)
        {
            var recipients = await _notificationRecipientRepository.GetAllNotificationRecipientsAsync(cancellationToken);
            return _mapper.Map<List<NotificationRecipientDTO>>(recipients);
        }

        // ✅ Update Notification Recipient (e.g., Mark as Read)
        public async ValueTask UpdateNotificationRecipientAsync(NotificationRecipientUpdateDTO recipientDto, CancellationToken cancellationToken = default)
        {
            if (recipientDto == null)
            {
                throw new ArgumentNullException(nameof(recipientDto), "Recipient data cannot be null.");
            }

            var recipient = await _notificationRecipientRepository.GetNotificationRecipientByIdAsync(recipientDto.Id, cancellationToken);
            if (recipient == null)
            {
                throw new KeyNotFoundException($"Recipient with ID {recipientDto.Id} not found.");
            }

            _mapper.Map(recipientDto, recipient);
            await _notificationRecipientRepository.UpdateNotificationRecipientAsync(recipient, cancellationToken);
        }

        // ✅ Delete Notification Recipient
        public async ValueTask DeleteNotificationRecipientAsync(int id, CancellationToken cancellationToken = default)
        {
            await _notificationRecipientRepository.DeleteNotificationRecipientAsync(id, cancellationToken);
        }

        // ✅ Get Recipients by Notification ID
        public async Task<List<NotificationRecipientDTO>> GetRecipientsByNotificationIdAsync(int notificationId, CancellationToken cancellationToken = default)
        {
            var recipients = await _notificationRecipientRepository.GetRecipientsByNotificationIdAsync(notificationId, cancellationToken);
            return _mapper.Map<List<NotificationRecipientDTO>>(recipients);
        }

        // ✅ Get Notifications for a User
        public async Task<List<NotificationRecipientDTO>> GetNotificationsForUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            var recipients = await _notificationRecipientRepository.GetNotificationsForUserAsync(userId, cancellationToken);
            return _mapper.Map<List<NotificationRecipientDTO>>(recipients);
        }

        // ✅ Mark a Single Notification as Read
        public async ValueTask MarkNotificationAsReadAsync(int recipientId, CancellationToken cancellationToken = default)
        {
            await _notificationRecipientRepository.MarkNotificationAsReadAsync(recipientId, cancellationToken);
        }

        // ✅ Mark All Notifications as Read for a User
        public async ValueTask MarkAllNotificationsAsReadForUserAsync(int userId, CancellationToken cancellationToken = default)
        {
            await _notificationRecipientRepository.MarkAllNotificationsAsReadForUserAsync(userId, cancellationToken);
        }
    }
}
