using Server.Events;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddSingleton<IUtilities, Utilities>()
    .AddSingleton<IEventStore, EventStore>()
    .AddSingleton<IInputString, InputString>()
    .AddTransient<IControllerFactory, ControllerFactory>()
    .AddSingleton<IControllerEvents, ServerControllerEvents>()
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
    })
    .AddCors(options =>
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
    .AddSignalR()
    .AddJsonProtocol();

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