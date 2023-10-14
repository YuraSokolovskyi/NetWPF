namespace RickAndMorty_API_CORE.Domain.Models;

public class Location
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Dimension { get; set; }

    public Location()
    {
        
    }
}