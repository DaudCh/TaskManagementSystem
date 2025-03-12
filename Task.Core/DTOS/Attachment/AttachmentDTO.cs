using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskI.Core.DTOS.Attachment
{
    public class AttachmentDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int TaskId { get; set; }
        public int UploadedBy { get; set; }
    }

    public class AttachmentCreateDTO
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int TaskId { get; set; }
        public int UploadedBy { get; set; }
    }

    public class AttachmentUpdateDTO
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int TaskId { get; set; }
    }

    public class AttachmentDeleteDTO
    {
        public int Id { get; set; }
    }
} 
