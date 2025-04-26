namespace Spotify.Domain.Entities;

public class Music : Entity
{
    public required string Name { get; set; }
    public int Year { get; set; }
    public required string MusicFilePath { get; set; }
    public int ArtistId { get; set; }
    public Artist? Artist { get; set; } // Navigation property
    public int? AlbumId { get; set; }
    public Album? Album { get; set; } // Navigation property
}
