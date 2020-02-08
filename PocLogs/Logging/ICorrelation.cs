using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocLogs.Logging
{
    public interface ICorrelation
    {
        CorrelationData GetCorrelation();

        void SetCorrelation(string id, string data);
    }
}
