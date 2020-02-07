using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocLogs.Service
{
    public interface ITaskService
    {
        Task<List<string>> GetTasks();
    }
}
