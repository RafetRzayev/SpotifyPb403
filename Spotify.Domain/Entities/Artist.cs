namespace Spotify.Domain.Entities;

public class Artist : Entity
{
    public required string Name { get; set; }
    public List<ArtistMusic> ArtistMusics { get; set; } = new();
    public List<Album> Albums { get; set; } = new();
}