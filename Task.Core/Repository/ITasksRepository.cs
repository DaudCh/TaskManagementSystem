using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskI.Core.Entities;

namespace TaskI.Core.Repository
{
    public interface ITasksRepository
    {
       
        ValueTask AddTaskAsync(Tasks task, CancellationToken cancellationToken = default);
        ValueTask UpdateTaskAsync(Tasks task, CancellationToken cancellationToken = default);
        Task<Tasks> GetTaskByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Tasks>> GetAllTasksAsync(CancellationToken cancellationToken = default);
        ValueTask DeleteTaskAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Tasks>> GetTasksByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<List<Tasks>> GetTasksByStatusAsync(string status, CancellationToken cancellationToken = default);
        Task<List<Tasks>> GetOverdueTasksAsync(CancellationToken cancellationToken = default);
    }
}
