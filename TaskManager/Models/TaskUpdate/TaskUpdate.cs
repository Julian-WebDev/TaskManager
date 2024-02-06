using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models.TaskUpdate
{
    public class TaskUpdate
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}