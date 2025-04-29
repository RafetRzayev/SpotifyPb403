namespace Spotify.Domain.Entities;

public class Music : Entity
{
    public required string Name { get; set; }
    public int Year { get; set; }
    public required string MusicFilePath { get; set; }
    public int? AlbumId { get; set; }
    public Album? Album { get; set; } // Navigation property
    public List<ArtistMusic> ArtistMusics { get; set; } = new();
}
