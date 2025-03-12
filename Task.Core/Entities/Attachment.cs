using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskI.Core.Entities
{
    public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

        // Foreign Key Relationship
        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public virtual Tasks Task { get; set; }

        [ForeignKey("User")]
        public int UploadedBy { get; set; }
        public virtual User User { get; set; }
    }
}
