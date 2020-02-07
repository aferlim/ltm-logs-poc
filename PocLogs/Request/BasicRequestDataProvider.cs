using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PocLogs.Request
{
    public class BasicRequestDataProvider : IBasicRequestDataProvider
    {
        public BasicRequest GetBasicRequest()
        {
            return new BasicRequest { ParticipantId = 123456 };
        }
    }
}