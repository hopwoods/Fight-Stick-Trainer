using ControllerInterface.Controllers;
using ControllerInterface.Factories;
using ControllerTestConsole.Events;
using ControllerTestConsole.Services;
using ControllerTestConsole.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var app = Host.CreateDefaultBuilder(args)
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

RunProgram(app.Services);

await app.RunAsync();


static void RunProgram(IServiceProvider services)
{
    using var serviceScope = services.CreateScope();
    var provider = serviceScope.ServiceProvider;
}
