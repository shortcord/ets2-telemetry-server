using System.Collections.Concurrent;
using Funbit.Ets.Telemetry.Server.Helpers;
using Microsoft.AspNetCore.SignalR;

namespace Funbit.Ets.Telemetry.Server.Hubs;

public sealed class Ets2TelemetryHub : Hub
{
    private static readonly ConcurrentDictionary<string, bool> ConnectedIds = new();

    private readonly Ets2TelemetryJsonProvider _telemetryJsonProvider;
    private readonly ILogger<Ets2TelemetryHub> _logger;
    
    public Ets2TelemetryHub(
        ILogger<Ets2TelemetryHub> logger,
        Ets2TelemetryJsonProvider telemetryJsonProvider)
    {
        _logger = logger;
        _telemetryJsonProvider = telemetryJsonProvider;
    }
    
    public async Task RequestData()
    {
        if (!ConnectedIds.IsEmpty)
        {
            _logger.LogInformation("Sending telemetry data to clients");
            await Clients.Caller.SendAsync("updateData", _telemetryJsonProvider.GetTelemetry());
        }
    }

    public override async Task OnConnectedAsync()
    {
        _logger.LogInformation("Client connecting: {id}", Context.ConnectionId);
        var result = ConnectedIds.TryAdd(Context.ConnectionId, true);
        if (result)
            _logger.LogInformation("Client connected: {id} (total: {total})", Context.ConnectionId, ConnectedIds.Count);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        ConnectedIds.TryRemove(Context.ConnectionId, out _);
        await base.OnDisconnectedAsync(exception);
    }
}
