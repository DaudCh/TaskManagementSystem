using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskI.Core.DTOS.Notification
{
    // ✅ Data Transfer Object for retrieving notifications
    public class NotificationDTO
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }  // e.g., "Task Update", "Reminder", etc.
        public DateTime Timestamp { get; set; }
        public int CreatedBy { get; set; }
        public List<int> RecipientUserIds { get; set; } // Multiple users can receive the notification
    }

    // ✅ DTO for creating a new notification
    public class NotificationCreateDTO
    {
        [Required]
        public int TaskId { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        public List<int> RecipientUserIds { get; set; }  // Users who will receive the notification
    }

    // ✅ DTO for updating a notification
    public class NotificationUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        public string Message { get; set; }
        public string Type { get; set; }
    }

    // ✅ DTO for marking a notification as read
    public class NotificationReadDTO
    {
        [Required]
        public int NotificationId { get; set; }

        [Required]
        public int UserId { get; set; } // The user who read the notification
    }

    // ✅ DTO for deleting a notification
    public class NotificationDeleteDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
