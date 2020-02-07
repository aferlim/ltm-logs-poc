using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocLogs.Logging
{
    public class CorrelationData<T>
    {
        public string ID { get; set; }
        public T Data { get; set; }
    }
}