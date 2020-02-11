using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Job.Middleware
{
    public class CheckHeaderHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if ( !request.Headers.Contains("X-Yandex-API-Key") )
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Do not find a header called X-Yandex-API-Key")
                };
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
