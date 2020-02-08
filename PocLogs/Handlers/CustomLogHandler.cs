using PocLogs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace PocLogs.Logging
{
    public class CustomLogHandler : DelegatingHandler
    {
        private readonly ILog _log;

        public CustomLogHandler(ILog log)
        {
            _log = log;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var logMetadata = BuildRequestMetadata(request);
            var response = await base.SendAsync(request, cancellationToken);
            logMetadata = BuildResponseMetadata(logMetadata, response);
            await SendToLog(logMetadata);
            return response;
        }
        private LogMetadata<long> BuildRequestMetadata(HttpRequestMessage request)
        {
            LogMetadata<long> log = new LogMetadata<long>
            {
                RequestMethod = request.Method.Method,
                RequestTimestamp = DateTime.Now,
                RequestUri = request.RequestUri.ToString()
            };

            return log;
        }
        private LogMetadata<long> BuildResponseMetadata(LogMetadata<long> logMetadata, HttpResponseMessage response)
        {
            logMetadata.ResponseStatusCode = response.StatusCode;
            logMetadata.ResponseTimestamp = DateTime.Now;
            logMetadata.ResponseContentType = response.Content.Headers.ContentType.MediaType;
            return logMetadata;
        }
        private async Task<bool> SendToLog(LogMetadata<long> logMetadata)
        {
            await Task.Run(() => _log.Info($"{logMetadata.RequestMethod} - "));
            
            // TODO: Write code here to store the logMetadata instance to a pre-configured log store...
            return true;
        }
    }
}