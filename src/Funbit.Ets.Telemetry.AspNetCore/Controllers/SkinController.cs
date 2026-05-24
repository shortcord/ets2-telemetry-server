using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Funbit.Ets.Telemetry.Server.Controllers;

[Controller]
[Route("/")]
public class SkinController : ControllerBase
{
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<SkinController> _logger;

    public SkinController(IWebHostEnvironment env, ILogger<SkinController> logger)
    {
        _env = env;
        _logger = logger;
    }
    
    private JsonElement? ReadSkinConfig(string skinDir)
    {
        var configPath = Path.Combine(skinDir, "config.json");
        if (!System.IO.File.Exists(configPath))
        {
            _logger.LogWarning("Skin config file not found: {ConfigPath}", configPath);
            return null;
        }

        try
        {
            using var document = JsonDocument.Parse(System.IO.File.ReadAllText(configPath));
            if (document.RootElement.TryGetProperty("config", out var config))
                return config.Clone();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reading skin config file: {ConfigPath}", configPath);
            return null;
        }

        return null;
    }
    
    [HttpGet("config.json")]
    public IActionResult? GetConfig()
    {
        var skinsRoot = Path.Combine(_env.WebRootPath, "skins");
        _logger.LogInformation("Reading skins from: {SkinsRoot}", skinsRoot);
        
        if (!Directory.Exists(skinsRoot))
        {
            _logger.LogWarning("Skins directory not found: {SkinsRoot}", skinsRoot);
            return new OkObjectResult(Array.Empty<object>());
        }

        var skins = Directory.EnumerateDirectories(skinsRoot)
            .Select(ReadSkinConfig)
            .Where(o => o is not null);
        
        _logger.LogInformation("Found {SkinCount} skins", skins.Count());
        return new OkObjectResult(skins);
    }
}