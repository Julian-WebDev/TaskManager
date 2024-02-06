using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Interfaces
{
    public interface TaskInterface
    {
        string id { get; set; }
        string Subject { get; set; }
        string Date { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}
