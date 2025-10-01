using System.Net.Http.Json;
using System.Text.Json;
using ServarrMcp.Radarr.Models;

namespace ServarrMcp.Radarr;

public sealed class RadarrService(HttpClient httpClient) {
    
    // - Private Properties

    private readonly JsonSerializerOptions _options = new() {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true
    };
    
    
    // - Functions

    public async Task<SystemStatus> GetSystemStatus() {
        var status = await httpClient.GetFromJsonAsync<SystemStatus>("/api/v3/system/status", _options);
        return status ?? throw new Exception("Failed to retrieve system status");
    }

    public async Task<DiskSpace[]> GetDiskSpace() {
        var diskSpace = await httpClient.GetFromJsonAsync<DiskSpace[]>("/api/v3/diskspace", _options);
        return diskSpace ?? [];
    }

    public async Task<Movie[]> GetMovies() {
        var movies = await httpClient.GetFromJsonAsync<Movie[]>("/api/v3/movie", _options);
        return movies ?? [];
    }
}