using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocLogs.Logging
{
    public class Log : ILog
    {
        private static NLog.Logger _logging;
        private readonly ICorrelation _correlation;

        public Log(ICorrelation correlation)
        {
            if (_logging == null)
                _logging = NLog.LogManager.GetCurrentClassLogger();

            _correlation = correlation;
        }

        public void Debug(string message)
        {
            _logging.Debug(message);
        }

        public void Info(string message)
        {
            var correlation = _correlation.GetCorrelation();
            _logging.Info($"{message} - corr_id: {correlation.ID} partId: {correlation.Data}");
        }
    }
}