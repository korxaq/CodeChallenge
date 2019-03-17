using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Api.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter, IDisposable
    {
        private readonly ILogger<GlobalExceptionFilter> _logger;

        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Dispose()
        {
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Global error cached");

            context.Result = new ObjectResult("An Error has occurred")
            {
                StatusCode = 500,
                DeclaredType = typeof(string)
            };
        }
    }
}
