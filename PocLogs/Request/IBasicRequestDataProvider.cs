using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocLogs.Request
{
    public interface IBasicRequestDataProvider
    {
        BasicRequest GetBasicRequest();
    }
}
