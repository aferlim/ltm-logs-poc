using PocLogs.Logging;
using PocLogs.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Http;

namespace PocLogs.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ITaskService _taskService;
        private readonly ILog _log;

        public ValuesController(ITaskService taskService, ILog log)
        {
            _taskService = taskService;
            _log = log;
        }

        // GET api/values
        public async Task<IEnumerable<string>> Get()
        {
            _log.Debug("Starting Request...");
            _log.Info("test");
            Trace.TraceError("If you're seeing this, something bad happened");
            Trace.WriteLine("Starting Request...");

            return await _taskService.GetTasks();

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string name, [FromBody]string description)
        {
            _log.Debug($"Starting Request...{name} - {description}");
            _log.Info($"Starting Request...{name} - {description}");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
