using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PocLogs.Service
{
    public class TaskService : ITaskService
    {
        public async Task<List<string>> GetTasks()
        {
            var result = new List<string> { };

            await Task.Run(() =>
            {
                result.Add("as");
            });

            return result;
        }
    }
}