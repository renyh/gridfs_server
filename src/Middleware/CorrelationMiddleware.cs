﻿using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace GridFSServer.Middleware
{
    internal sealed class CorrelationMiddleware
    {
        private readonly RequestDelegate _next;

        public CorrelationMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var requestId = httpContext.Features.Get<IHttpRequestIdentifierFeature>()?.TraceIdentifier;
            if (!string.IsNullOrWhiteSpace(requestId))
            {
                httpContext.Response.Headers.Add("X-Request-ID", requestId);
            }

            return _next(httpContext);
        }
    }
}
