using Spotify.Application.DTOs.ArtistDtos;
using Spotify.Application.DTOs.ArtistMusicDtos;

namespace Spotify.Application.DTOs.MusicDtos;

public class MusicDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Year { get; set; }
    public string? MusicFilePath { get; set; }
    public List<ArtistMusicDto> ArtistMusics { get; set; } = new();
    public string? AlbumTitle { get; set; }
}

public class MusicCreateDto
{
    public required string Name { get; set; }
    public int Year { get; set; }
    public required string MusicFilePath { get; set; }
    public List<int> ArtistIds { get; set; } = new();
    public int? AlbumId { get; set; }
}

public class MusicUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Year { get; set; }
    public string? MusicFilePath { get; set; }
    public List<int> RemovedArtistId { get; set; } = new();
    public List<int> AddedArtistId { get; set; } = new();
    public int? AlbumId { get; set; }
}
