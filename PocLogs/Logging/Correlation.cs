using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocLogs.Logging
{
    public class Correlation : ICorrelation
    {
        public CorrelationData<T> GetCorrelation<T>()
        {
            throw new NotImplementedException();
        }
    }
}