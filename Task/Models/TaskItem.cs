using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class TaskItem
    {
        public string TaskID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; } // e.g., High, Medium, Low
        public string Status { get; set; } // e.g., Pending, In Progress, Completed
        public DateTime Deadline { get; set; }
        public string CreatedBy { get; set; }
    }
}
