using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskI.Core.Entities;
using TaskI.Core.Repository;

namespace TaskI.Repostories
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AttachmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Add Attachment
        public async ValueTask AddAttachmentAsync(Attachment attachment, CancellationToken cancellationToken = default)
        {
            if (attachment == null)
            {
                throw new ArgumentNullException(nameof(attachment), "Attachment cannot be null.");
            }

            await _context.Attachments.AddAsync(attachment, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // ✅ Get Attachment by ID
        public async Task<Attachment> GetAttachmentByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var attachment = await _context.Attachments
                .AsTracking()
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (attachment == null)
            {
                throw new KeyNotFoundException($"Attachment with ID {id} not found.");
            }

            return attachment;
        }

        // ✅ Get All Attachments
        public async Task<List<Attachment>> GetAllAttachmentsAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Attachments.ToListAsync(cancellationToken);
        }

        // ✅ Update Attachment
        public async ValueTask UpdateAttachmentAsync(Attachment attachment, CancellationToken cancellationToken = default)
        {
            if (attachment == null)
            {
                throw new ArgumentNullException(nameof(attachment), "Attachment cannot be null.");
            }

            var existingAttachment = await _context.Attachments
                .AsTracking()
                .FirstOrDefaultAsync(a => a.Id == attachment.Id, cancellationToken);

            if (existingAttachment == null)
            {
                throw new KeyNotFoundException($"Attachment with ID {attachment.Id} not found.");
            }

            _context.Attachments.Update(attachment);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // ✅ Delete Attachment
        public async ValueTask DeleteAttachmentAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var attachment = await _context.Attachments
                    .AsTracking()
                    .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

                if (attachment == null)
                {
                    throw new KeyNotFoundException($"Attachment with ID {id} not found.");
                }

                _context.Attachments.Remove(attachment);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting attachment: {ex.Message}");
                throw;
            }
        }
    }
}
