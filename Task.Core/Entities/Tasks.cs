using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskI.Core.Entities
{
    public class Tasks
    {

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            [Required, StringLength(100)]
            public string Title { get; set; }

            public string Description { get; set; }

            [Required]
            public string Priority { get; set; }

            [Required]
            public string Status { get; set; }

            public DateTime Deadline { get; set; }

            // Foreign Key Relationship
            [ForeignKey("User")]
            public int CreatedBy { get; set; }
            public virtual User User { get; set; }

            // Navigation Properties
            public virtual ICollection<Attachment> Attachments { get; set; }
            public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        }
    }

