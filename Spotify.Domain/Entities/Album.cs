namespace Spotify.Domain.Entities;

public class Album : Entity
{
    public required string Title { get; set; }
    public int Year { get; set; }
    public int ArtistId { get; set; }
    public Artist? Artist { get; set; } // Navigation property
    public List<Music> Musics { get; set; } = new();
}
