using System.Text.Json;
using Funbit.Ets.Telemetry.Data;

namespace Funbit.Ets.Telemetry.Server.Helpers;

public sealed class Ets2TelemetryJsonProvider
{
    private readonly ScsTelemetryClient _client;
    private readonly bool _useTestTelemetryData;
    
    public Ets2TelemetryJsonProvider(ScsTelemetryClient client, IConfiguration configuration)
    {
        _client = client;
        _useTestTelemetryData = configuration.GetValue<bool>("UseTestTelemetryData");
    }
    
    public JsonElement? GetTelemetry(bool useTestTelemetryData = false)
    {
        if (useTestTelemetryData || _useTestTelemetryData)
        {
            var path = Path.Combine(AppContext.BaseDirectory, "Ets2TestTelemetry.json");
            using var fileStream = File.OpenRead(path);
            return JsonSerializer.Deserialize<JsonElement>(fileStream);
        }

        var telemetry = _client.Read();
        if (telemetry is null)
            return null;

        return JsonSerializer.SerializeToElement(telemetry);
    }
}
