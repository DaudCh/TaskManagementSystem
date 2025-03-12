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
    public class TasksRepository : ITasksRepository
    {
        private readonly ApplicationDbContext _context;

        public TasksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Add Task
        public async ValueTask AddTaskAsync(Tasks task, CancellationToken cancellationToken = default)
        {
            await _context.Tasks.AddAsync(task, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // ✅ Update Task
        public async ValueTask UpdateTaskAsync(Tasks task, CancellationToken cancellationToken = default)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync(cancellationToken);
        }

        // ✅ Get Task by ID
        public async Task<Tasks> GetTaskByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Tasks.FindAsync(new object[] { id }, cancellationToken);
        }

        // ✅ Get All Tasks
        public async Task<List<Tasks>> GetAllTasksAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Tasks.ToListAsync(cancellationToken);
        }

        // ✅ Delete Task
        public async ValueTask DeleteTaskAsync(int id, CancellationToken cancellationToken = default)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        // ✅ Get Tasks by User ID
        public async Task<List<Tasks>> GetTasksByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return await _context.Tasks
                .Where(t => t.CreatedBy == userId)
                .ToListAsync(cancellationToken);
        }

        // ✅ Get Tasks by Status
        public async Task<List<Tasks>> GetTasksByStatusAsync(string status, CancellationToken cancellationToken = default)
        {
            return await _context.Tasks
                .Where(t => t.Status == status)
                .ToListAsync(cancellationToken);
        }

        // ✅ Get Overdue Tasks (Tasks past deadline)
        public async Task<List<Tasks>> GetOverdueTasksAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Tasks
                .Where(t => t.Deadline < DateTime.UtcNow && t.Status != "Completed")
                .ToListAsync(cancellationToken);
        }
    }
}
