using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace ServarrMcp.Radarr;

[McpServerToolType]
public class RadarrTools(RadarrService radarrService) {
    
    // - Functions
    
    [McpServerTool, Description("Get the movies that are monitored with Radarr.")]
    public async Task<string> GetMonitoredMovies() {
        var movies = await radarrService.GetMovies();
        return JsonSerializer.Serialize(movies);
    }

    [McpServerTool, Description("Get the system information and status for Radarr.")]
    public async Task<string> GetRadarrSystemStatus() {
        var status = await radarrService.GetSystemStatus();
        return JsonSerializer.Serialize(status);
    }

    [McpServerTool, Description("Get the total and available disk space for Radarr..")]
    public async Task<string> GetRadarrDiskSpace() {
        var diskSpace = await radarrService.GetDiskSpace();
        return JsonSerializer.Serialize(diskSpace);
    }
}