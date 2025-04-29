namespace Spotify.Domain.Entities;

public class ArtistMusic : Entity
{
    public int ArtistId { get; set; }
    public Artist? Artist { get; set; } // Navigation property
    public int MusicId { get; set; }
    public Music? Music { get; set; } // Navigation property
}