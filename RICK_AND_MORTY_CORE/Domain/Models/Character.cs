namespace RickAndMorty_API_CORE.Domain.Models;

public class Character
{
    public string Id { get; set; }
    public string? Name { get; set; }
    public string? Status { get; set; }
    public string? Species { get; set; }
    public string? Gender { get; set; }
    public string? Location { get; set; }
    public string? LocationUrl { get; set; }
    public string? ImageUrl { get; set; }

    public Character()
    {
        
    }
}