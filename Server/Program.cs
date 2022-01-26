using ControllerInterface.Controllers;
using ControllerInterface.Events;
using ControllerInterface.Factories;
using ControllerInterface.Pocos;
using ControllerInterface.Services;
using Microsoft.AspNetCore.SignalR;
using Server;
using Server.Hubs;
using Server.Utilities;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddSingleton<IUtilities, Utilities>()
    .AddSingleton<IInputString, InputString>()
    .AddTransient<IControllerFactory, ControllerFactory>()
    .AddTransient<IControllerEvents, ServerControllerEvents>()
    .AddSingleton<IXboxController>(provider =>
    {
        var factory = provider.GetRequiredService<IControllerFactory>();
        return factory.CreateXboxController();
    })
    .AddLogging(logging =>
    {
        logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
        logging.AddDebug();
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
    .AddHostedService<ControllerWatcherService>()
    .AddSignalR();

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