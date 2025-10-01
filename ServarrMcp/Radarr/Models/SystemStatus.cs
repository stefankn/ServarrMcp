namespace ServarrMcp.Radarr.Models;

public class SystemStatus {
    
    // - Properties
    
    public required string Version { get; init; }
    public required string OsName { get; init; }
    public required string OsVersion { get; init; }
}