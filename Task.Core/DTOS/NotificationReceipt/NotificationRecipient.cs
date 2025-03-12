using System;
using System.ComponentModel.DataAnnotations;

namespace TaskI.Core.DTOS.NotificationRecipient
{
    // ✅ Data Transfer Object for retrieving notification recipients
    public class NotificationRecipientDTO
    {
        public int Id { get; set; }
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }  // e.g., "Unread", "Read", "Dismissed"
    }

    // ✅ DTO for creating a new notification recipient
    public class NotificationRecipientCreateDTO
    {
        [Required]
        public int NotificationId { get; set; }

        [Required]
        public int UserId { get; set; }

        public string Status { get; set; } = "Unread";  // Default to "Unread"
    }

    // ✅ DTO for updating a notification recipient (e.g., marking as read)
    public class NotificationRecipientUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        public string Status { get; set; }
    }

    // ✅ DTO for deleting a notification recipient
    public class NotificationRecipientDeleteDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
