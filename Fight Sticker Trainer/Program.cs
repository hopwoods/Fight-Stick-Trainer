using ControllerHost;
using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
            .AddTransient<IControllerFactory, ControllerFactory>()
            .AddSingleton<IXboxController>(provider =>
            {
                var factory = provider.GetRequiredService<IControllerFactory>();
                return factory.CreateXboxController();
            })
            .AddHostedService<ControllerPollerService>()
    )
    .Build();

RunProgram(host.Services, "Scope 1");

await host.RunAsync();


static void RunProgram(IServiceProvider services, string scope)
{
    using var serviceScope = services.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var xboxController = provider.GetRequiredService<IXboxController>();
}
