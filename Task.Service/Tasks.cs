using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TaskI.Core.DTOS.Tasks;
using TaskI.Core.Entities;
using TaskI.Core.Repository;
using TaskI.Core.Services;

namespace TaskI.Services
{
    public class Tasks : ITasksRepository
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly IMapper _mapper;

        public Tasks(ITasksRepository tasksRepository, IMapper mapper)
        {
            _tasksRepository = tasksRepository;
            _mapper = mapper;
        }

        // ✅ Create Task
        public async ValueTask<TasksDTO> CreateTaskAsync(TasksCreateDTO taskCreateDTO, CancellationToken cancellationToken = default)
        {
            var task = _mapper.Map<Tasks>(taskCreateDTO);
            await _tasksRepository.AddTaskAsync(task, cancellationToken);
            return _mapper.Map<TasksDTO>(task);
        }

        // ✅ Update Task
        public async ValueTask<TasksDTO> UpdateTaskAsync(TasksUpdateDTO taskUpdateDTO, CancellationToken cancellationToken = default)
        {
            var task = await _tasksRepository.GetTaskByIdAsync(taskUpdateDTO.Id, cancellationToken);
            if (task == null)
                throw new Exception("Task not found.");

            _mapper.Map(taskUpdateDTO, task);
            await _tasksRepository.UpdateTaskAsync(task, cancellationToken);
            return _mapper.Map<TasksDTO>(task);
        }

        // ✅ Delete Task
        public async ValueTask<bool> DeleteTaskAsync(int taskId, CancellationToken cancellationToken = default)
        {
            var task = await _tasksRepository.GetTaskByIdAsync(taskId, cancellationToken);
            if (task == null)
                return false;

            await _tasksRepository.DeleteTaskAsync(taskId, cancellationToken);
            return true;
        }

        // ✅ Get Task by ID
        public async Task<TasksDTO> GetTaskByIdAsync(int taskId, CancellationToken cancellationToken = default)
        {
            var task = await _tasksRepository.GetTaskByIdAsync(taskId, cancellationToken);
            return task == null ? null : _mapper.Map<TasksDTO>(task);
        }

        // ✅ Get All Tasks
        public async Task<List<TasksDTO>> GetAllTasksAsync(CancellationToken cancellationToken = default)
        {
            var tasks = await _tasksRepository.GetAllTasksAsync(cancellationToken);
            return _mapper.Map<List<TasksDTO>>(tasks);
        }

        // ✅ Get Tasks by User ID
        public async Task<List<TasksDTO>> GetTasksByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var tasks = await _tasksRepository.GetTasksByUserIdAsync(userId, cancellationToken);
            return _mapper.Map<List<TasksDTO>>(tasks);
        }

        // ✅ Get Tasks by Status
        public async Task<List<TasksDTO>> GetTasksByStatusAsync(string status, CancellationToken cancellationToken = default)
        {
            var tasks = await _tasksRepository.GetTasksByStatusAsync(status, cancellationToken);
            return _mapper.Map<List<TasksDTO>>(tasks);
        }

        // ✅ Get Overdue Tasks
        public async Task<List<TasksDTO>> GetOverdueTasksAsync(CancellationToken cancellationToken = default)
        {
            var tasks = await _tasksRepository.GetOverdueTasksAsync(cancellationToken);
            return _mapper.Map<List<TasksDTO>>(tasks);
        }
    }
}
