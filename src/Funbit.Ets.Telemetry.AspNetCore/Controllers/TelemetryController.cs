using Funbit.Ets.Telemetry.Server.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Funbit.Ets.Telemetry.Server.Controllers;

[ApiController]
[Route("api/ets2/telemetry")]
public class TelemetryController : ControllerBase
{
    private readonly Ets2TelemetryJsonProvider _jsonProvider;
    
    public TelemetryController(Ets2TelemetryJsonProvider jsonProvider)
    {
        _jsonProvider = jsonProvider;
    }
    
    [HttpGet]
    public IActionResult GetTelemetryData([FromQuery] bool useTestTelemetryData = false)
    {
        return new OkObjectResult(_jsonProvider.GetTelemetry(useTestTelemetryData));
    }
}
