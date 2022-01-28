using var app = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostingContext, services) =>
        services
            .AddTransient<IUtilities, ControllerTestConsole.Utilities.Utilities>()
            .AddTransient<IControllerFactory, ControllerFactory>()
            .AddTransient<IControllerEvents, ConsoleControllerEvents>()
            .AddSingleton<IXboxController>(provider =>
            {
                var factory = provider.GetRequiredService<IControllerFactory>();
                return factory.CreateXboxController();
            })
            .AddLogging(logging =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddDebug();
                logging.AddConsole();
            })
            .AddHostedService<ControllerWatcherService>()
    )
    .Build();

RunProgram(app.Services);

await app.RunAsync();


static void RunProgram(IServiceProvider services)
{
    using var serviceScope = services.CreateScope();
    var provider = serviceScope.ServiceProvider;
}
