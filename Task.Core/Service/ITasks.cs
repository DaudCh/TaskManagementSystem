using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskI.Core.DTOS.Tasks;

namespace TaskI.Core.Service
{
    public interface ITasksService
    {
        
        Task AddTaskAsync(TasksCreateDTO taskCreateDTO, CancellationToken cancellationToken = default);
        Task UpdateTaskAsync(TasksUpdateDTO taskUpdateDTO, CancellationToken cancellationToken = default);
        Task<TasksDTO> GetTaskByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<TasksDTO>> GetAllTasksAsync(CancellationToken cancellationToken = default);
        Task DeleteTaskAsync(TasksDeleteDTO taskDeleteDTO, CancellationToken cancellationToken = default);
        Task<List<TasksDTO>> GetTasksByUserIdAsync(int userId, CancellationToken cancellationToken = default);
        Task<List<TasksDTO>> GetTasksByStatusAsync(string status, CancellationToken cancellationToken = default);
        Task<List<TasksDTO>> GetOverdueTasksAsync(CancellationToken cancellationToken = default);
    }
}
