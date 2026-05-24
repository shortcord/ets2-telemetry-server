using System.Text.Json;
using System.Text.Json.Serialization;
using Funbit.Ets.Telemetry.Data;
using Funbit.Ets.Telemetry.Server.Helpers;
using Funbit.Ets.Telemetry.Server.Hubs;
using Microsoft.OpenApi.Models;

namespace Funbit.Ets.Telemetry.Server;

public sealed class Startup
{
    private readonly IConfiguration _configuration;
    
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyHeader()
                      .AllowAnyMethod()
                      .SetIsOriginAllowed(_ => true)
                      .AllowCredentials();
            });
        });

        services
            .AddControllers()
            .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ETS2 Telemetry ASP.NET Core",
                Version = "v1"
            });
        });

        services.AddSingleton(new ScsTelemetryClient(_configuration.GetValue<string>("EtsTelemetryServer:MappedFileName")));
        services.AddSingleton<Ets2TelemetryJsonProvider>();
        services.AddSignalR(options =>
        {
            options.ClientTimeoutInterval = TimeSpan.FromSeconds(12);
            options.KeepAliveInterval = TimeSpan.FromSeconds(3);
        }).AddJsonProtocol(options =>
        {
            options.PayloadSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "ETS2 Telemetry ASP.NET Core v1");
        });

        app.UseDefaultFiles(new DefaultFilesOptions
        {
            FileProvider = env.WebRootFileProvider
        });

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = env.WebRootFileProvider
        });

        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHub<Ets2TelemetryHub>("/signalr");
        });
    }
}
