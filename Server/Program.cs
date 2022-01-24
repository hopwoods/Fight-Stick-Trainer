using Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<TrainerHub>("/hub");
});

app.Run();
