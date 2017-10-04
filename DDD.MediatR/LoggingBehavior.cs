using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DDD.MediatR
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        //private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        //public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public LoggingBehavior() { }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next)
        {
            //_logger.LogInformation($"Handling {typeof(TRequest).Name}");
            var response = await next();
            //_logger.LogInformation($"Handled {typeof(TResponse).Name}");
            return response;
        }
    }
}
