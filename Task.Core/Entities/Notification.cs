using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskI.Service;

namespace TaskI.Core.Entities
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Foreign Key Relationship
        
        public int TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual Tasks Task { get; set; }

        [ForeignKey("User")]
        public int CreatedBy { get; set; }
        public virtual User User { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Type { get; set; }

        public DateTime Timestamp { get; set; }

        // Navigation Property
        public virtual ICollection<NotificationRecipient> NotificationRecipients { get; set; }
    }
}
