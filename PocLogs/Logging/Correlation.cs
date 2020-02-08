using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocLogs.Logging
{
    public class Correlation : ICorrelation
    {
        private string Id;
        private object Data;

        private CorrelationData _correlationData;

        private Guid _instance;

        public Correlation()
        {
            _instance = Guid.NewGuid();
        }


        public CorrelationData GetCorrelation()
        {
            return _correlationData;
        }

        public void SetCorrelation(string id, string data)
        {
            _correlationData = new CorrelationData
            {
                ID = id,
                Data = data
            };
        }

    }
}