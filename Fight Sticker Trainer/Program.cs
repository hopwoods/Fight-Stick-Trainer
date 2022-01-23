using ControllerHost;
using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostingContext, services) =>
        services
            .AddTransient<IControllerFactory, ControllerFactory>()
            .AddSingleton<IXboxController>(provider =>
            {
                var factory = provider.GetRequiredService<IControllerFactory>();
                return factory.CreateXboxController();
            })
            .AddHostedService<ControllerPollerService>()
            .AddLogging(logging =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
            })
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
