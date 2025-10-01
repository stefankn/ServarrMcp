namespace ServarrMcp.Radarr.Models;

public class DiskSpace {
    
    // - Properties
    
    public required string Path { get; init; }
    public double FreeSpace { get; init; }
    public double TotalSpace { get; init; }
}