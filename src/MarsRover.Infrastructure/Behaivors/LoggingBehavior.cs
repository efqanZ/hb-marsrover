using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MarsRover.Infrastructure.Behaivors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType().Name;
            var requestGuid = Guid.NewGuid().ToString();

            var requestId = $"{requestName}-[{requestGuid}]";

            _logger.LogInformation("[START] {requestName}", requestId);
            TResponse response;

            var stopwatch = Stopwatch.StartNew();
            try
            {
                _logger.LogInformation("[PROPS] {requestName} {@requestModel}", requestId, request);

                response = await next();

                _logger.LogInformation("[RESP] {requestName} {@responseModel}", requestId, response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[ERR] {requestName} {expMesage}", requestId, ex.Message);
                throw ex;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation("[END] {requestName}; ExecutionTime= {executionTime} ms", requestId, stopwatch.ElapsedMilliseconds);
            }

            return response;
        }
    }
}