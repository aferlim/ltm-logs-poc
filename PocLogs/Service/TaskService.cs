using PocLogs.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PocLogs.Service
{
    public class TaskService : ITaskService
    {
        private readonly ILog _log;
        public TaskService(ILog log)
        {
            _log = log;
        }

        public async Task<List<string>> GetTasks()
        {
            var result = new List<string> { };

            await Task.Run(() =>
            {
                result.Add("as");
            });

            _log.Info("Success Service");

            return result;
        }
    }
}