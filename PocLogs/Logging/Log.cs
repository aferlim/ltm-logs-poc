using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocLogs.Logging
{
    public class Log : ILog
    {
        private static NLog.Logger _logging;

        public Log()
        {
            if (_logging == null)
                _logging = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Debug(string message)
        {
            _logging.Debug(message);
        }

        public void Info(string message)
        {
            _logging.Info(message);
        }
    }
}