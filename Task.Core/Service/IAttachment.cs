using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TaskI.Core.DTOS.Attachment;

namespace TaskI.Core.Service
{
    public interface IAttachment
    {
        Task AddAttachmentAsync(AttachmentCreateDTO attachmentCreateDTO,CancellationToken cancellationToken);
        Task UpdateAttachmentAsync(AttachmentUpdateDTO attachmentUpdateDTO,CancellationToken cancellationToken);
        Task<AttachmentDTO> GetAttachmentAsync(int Id);
        Task<List<Attachment>> GetAllAttachmentsAsync(int Id);
        Task DeleteAttachmentAsync(int Id);
    }
}
