using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManager.Interfaces;

namespace TaskManager.Interfaces.Task
{
    public class Task : TaskInterface
    {
        public string id { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}