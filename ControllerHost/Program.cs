using ControllerHost;
using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostingContext, services) =>
        services
            .AddTransient<IUtilities, Utilities>()
            .AddTransient<IControllerFactory, ControllerFactory>()
            .AddTransient<IControllerWatcherFactory, ControllerWatcherFactory>()
            .AddTransient<IControllerEvents, ConsoleControllerEvents>()
            .AddSingleton<IXboxController>(provider =>
            {
                var factory = provider.GetRequiredService<IControllerFactory>();
                return factory.CreateXboxController();
            })
            .AddSingleton<IXboxControllerWatcher>(provider =>
            {
                var controller = provider.GetRequiredService<IXboxController>();
                var factory = provider.GetRequiredService<IControllerWatcherFactory>();
                return factory.CreateXBoxControllerWatcher(controller);
            })
            .AddLogging(logging =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddDebug();
                logging.AddConsole();
            })
            .AddHostedService<ControllerStatusService>()
    )
    .Build();

RunProgram(host.Services);

await host.RunAsync();


static void RunProgram(IServiceProvider services)
{
    using var serviceScope = services.CreateScope();
    var provider = serviceScope.ServiceProvider;
}
