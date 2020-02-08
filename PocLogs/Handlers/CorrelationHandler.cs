using PocLogs.Logging;
using PocLogs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PocLogs.Handlers
{
    public class CorrelationHandler : DelegatingHandler
    {
        private readonly IBasicRequestDataProvider _basicRequestDataProvider;
        private readonly ICorrelation _correlation;

        public CorrelationHandler(ICorrelation correlation, IBasicRequestDataProvider basicRequestDataProvider)
        {
            _basicRequestDataProvider = basicRequestDataProvider;
            _correlation = correlation;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            SetCorrelation(request);
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }

        private void SetCorrelation(HttpRequestMessage request)
        {
            var correlationId = request.Headers.Contains("correlationId") ? 
                request.Headers.GetValues("correlationId").FirstOrDefault() : Guid.NewGuid().ToString();

            var correlationData = request.Headers.Contains("correlationData") ?
                request.Headers.GetValues("correlationData").FirstOrDefault() : 
                _basicRequestDataProvider.GetBasicRequest().ParticipantId.ToString();

            _correlation.SetCorrelation(correlationId, correlationData);
        }
    }
}