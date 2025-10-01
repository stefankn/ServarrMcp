
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServarrMcp.Radarr;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole(options => {
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

var mcpServerBuilder = builder.Services
    .AddMcpServer()
    .WithHttpTransport();

var radarrHost = builder.Configuration["RADARR_HOST"];
if (radarrHost != null) {
    builder.Services.AddHttpClient<RadarrService>(client => {
        client.BaseAddress = new Uri(radarrHost);
        
        var radarrApiKey = builder.Configuration["RADARR_API_KEY"];
        if (radarrApiKey != null) {
            client.DefaultRequestHeaders.Add("X-Api-Key", radarrApiKey);
        }
    });

    mcpServerBuilder.WithTools<RadarrTools>();
}

var app = builder.Build();
app.MapMcp();
app.Run();