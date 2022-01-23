using ControllerInterface.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<IControllerFactory, ControllerFactory>())
    .Build();

RunProgram(host.Services, "Scope 1");

await host.RunAsync();


static void RunProgram(IServiceProvider services, string scope)
{
    using var serviceScope = services.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var factory = provider.GetRequiredService<IControllerFactory>();
    var xboxController = factory.CreateXboxController();

    xboxController.Update();

    Console.WriteLine($"Xbox Controller is connected: {xboxController.IsConnected}");

}
