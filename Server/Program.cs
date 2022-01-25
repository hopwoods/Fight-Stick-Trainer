using ControllerInterface.Controllers;
using ControllerInterface.Events;
using ControllerInterface.Factories;
using ControllerInterface.Pocos;
using ControllerInterface.Services;
using ControllerTestConsole.Utilities;
using Microsoft.AspNetCore.SignalR;
using Server;
using Server.Client;
using Server.Hubs;
using Server.Services;
using Server.Utilities;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddSingleton<IUtilities, Utilities>()
    .AddSingleton<IInputString, InputString>()
    .AddSingleton<ITrainerHubClient, TrainerHubClient>()
    .AddTransient<IControllerFactory, ControllerFactory>()
    .AddTransient<IControllerWatcherFactory, ControllerWatcherFactory>()
    .AddTransient<IControllerEvents, ServerControllerEvents>()
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
        logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
        //logging.AddDebug();
        logging.AddConsole();
    }).AddCors(options =>
    {
        options.AddPolicy(name: myAllowSpecificOrigins, policyBuilder =>
        {
            policyBuilder
                .WithOrigins("http://localhost:3000")
                .AllowCredentials()
                .AllowAnyHeader();
        });
    })
    .AddHostedService<ControllerWatcherService>();

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(myAllowSpecificOrigins);
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<TrainerHub>("/hub");
});

app.Run();