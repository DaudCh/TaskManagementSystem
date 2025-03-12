using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskI.Core.Entities;

namespace TaskI.Core.Repository
{
    public interface IAttachmentRepository
    {
        ValueTask AddAttachmentAsync(Attachment attachment, CancellationToken cancellationToken = default);
        ValueTask UpdateAttachmentAsync(Attachment attachment, CancellationToken cancellationToken = default);
        Task<Attachment> GetAttachmentByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Attachment>> GetAllAttachmentsAsync(CancellationToken cancellationToken = default);
        ValueTask DeleteAttachmentAsync(int id, CancellationToken cancellationToken = default);
    }
}
