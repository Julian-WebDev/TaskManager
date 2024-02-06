using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManager.Models.TaskCreation
{
    public class AddTask
    {
        [Required]
        public string Subject { get; set; }
        public string Deadline { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public string TaskDescription { get; set; }
    }
}