using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TaskI.Core.Entities;
using TaskI.Core.Repository;
using TaskI.Core.Services;
using TaskI.Core.DTOS.Attachment;
using System.Net.Mail;

namespace TaskI.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IMapper _mapper;

        public AttachmentService(IAttachmentRepository attachmentRepository, IMapper mapper)
        {
            _attachmentRepository = attachmentRepository;
            _mapper = mapper;
        }

        // ✅ Add Attachment
        public async ValueTask AddAttachmentAsync(AttachmentCreateDTO attachmentDto, CancellationToken cancellationToken = default)
        {
            if (attachmentDto == null)
            {
                throw new ArgumentNullException(nameof(attachmentDto), "Attachment data cannot be null.");
            }

            var attachment = _mapper.Map<Attachment>(attachmentDto);
            await _attachmentRepository.AddAttachmentAsync(attachment, cancellationToken);
        }

        // ✅ Get Attachment by ID
        public async Task<AttachmentDTO> GetAttachmentByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var attachment = await _attachmentRepository.GetAttachmentByIdAsync(id, cancellationToken);
            return _mapper.Map<AttachmentDTO>(attachment);
        }

        // ✅ Get All Attachments
        public async Task<List<AttachmentDTO>> GetAllAttachmentsAsync(CancellationToken cancellationToken = default)
        {
            var attachments = await _attachmentRepository.GetAllAttachmentsAsync(cancellationToken);
            return _mapper.Map<List<AttachmentDTO>>(attachments);
        }

        // ✅ Update Attachment
        public async ValueTask UpdateAttachmentAsync(int id, AttachmentUpdateDTO attachmentDto, CancellationToken cancellationToken = default)
        {
            if (attachmentDto == null)
            {
                throw new ArgumentNullException(nameof(attachmentDto), "Attachment data cannot be null.");
            }

            var existingAttachment = await _attachmentRepository.GetAttachmentByIdAsync(id, cancellationToken);
            if (existingAttachment == null)
            {
                throw new KeyNotFoundException($"Attachment with ID {id} not found.");
            }

            _mapper.Map(attachmentDto, existingAttachment);
            await _attachmentRepository.UpdateAttachmentAsync(existingAttachment, cancellationToken);
        }

        // ✅ Delete Attachment
        public async ValueTask DeleteAttachmentAsync(int id, CancellationToken cancellationToken = default)
        {
            await _attachmentRepository.DeleteAttachmentAsync(id, cancellationToken);
        }
    }
}
