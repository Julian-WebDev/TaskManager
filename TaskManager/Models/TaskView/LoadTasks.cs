using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models.TaskView
{
    public class LoadTasks
    {
        public int Id { get; set; }
        public string TaskSubject { get; set; }
        public string TaskDeadline { get; set; }
        public string TaskName { get; set; }
        public int Completed { get; set; }
        public string Description { get; set; }
    }
}