using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Models
{
    public class Notification
    {
        public string NotificationID { get; set; }
        public string TaskID { get; set; }
        public string CreatedBy { get; set; }
        public string Message { get; set; }
        public string Type { get; set; } 
        public DateTime Timestamp { get; set; }
    }
}
