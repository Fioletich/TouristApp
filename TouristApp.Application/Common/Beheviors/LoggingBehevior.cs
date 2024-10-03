using MediatR;
using Serilog;

namespace TouristApp.Application.Common.Beheviors;

public class LoggingBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> {
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken) {
        var requestName = typeof(TRequest).Name;
        
        Log.Information("Request: {Name} {@Request}",
            requestName, request);

        var response = await next();

        return response;
    }
}