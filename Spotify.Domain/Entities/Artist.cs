namespace Spotify.Domain.Entities;

public class Artist : Entity
{
    public required string Name { get; set; }
    public List<Music> Musics { get; set; } = new();
    public List<Album> Albums { get; set; } = new();
}