using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Interfaces.User
{
    public interface IUser
    {
        string Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
