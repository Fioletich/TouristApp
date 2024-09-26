using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TouristApp.Application.Routes.Queries.GetAllRoutes;

namespace TestApp;

public class ConsoleApp : IHostedService {
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<ConsoleApp> _logger;
    
    public ConsoleApp(IServiceScopeFactory serviceScopeFactory, ILogger<ConsoleApp> logger) {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken) {
        IMediator? mediator;
        await using var scope = _serviceScopeFactory.CreateAsyncScope();

        mediator = scope.ServiceProvider.GetService<IMediator>();
        
        
    }

    public Task StopAsync(CancellationToken cancellationToken) {
        throw new NotImplementedException();
    }
}