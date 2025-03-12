using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace TaskI.Core.DTOS.Tasks
{
    // ✅ DTO for retrieving task details
    public class TasksDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }  // e.g., "High", "Medium", "Low"
        public string Status { get; set; }  // e.g., "Pending", "In Progress", "Completed"
        public DateTime Deadline { get; set; }
        public int CreatedBy { get; set; }
    }

    // ✅ DTO for creating a new task
    public class TasksCreateDTO
    {
        [Required, StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime Deadline { get; set; }

        [Required]
        public int CreatedBy { get; set; }
    }

    // ✅ DTO for updating an existing task
    public class TasksUpdateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime Deadline { get; set; }
    }

    // ✅ DTO for deleting a task
    public class TasksDeleteDTO
    {
        [Required]
        public int Id { get; set; }
    }
}
