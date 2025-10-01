namespace ServarrMcp.Radarr.Models;

public class Movie {
    
    // - Properties
    
    public int Id { get; init; }
    public required string Title { get; init; }
    public required string Status { get; init; }
    public string? Overview { get; init; }
    public string? InCinemas { get; init; }
    public string? ReleaseDate { get; init; }
    public int? Year { get; init; }
}