using Spotify.Application.DTOs.ArtistDtos;

namespace Spotify.Application.DTOs.MusicDtos;

public class MusicDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Year { get; set; }
    public string? MusicFilePath { get; set; }
    public ArtistDto? Artist { get; set; }
    public string? AlbumTitle { get; set; }
}

public class MusicCreateDto
{
    public required string Name { get; set; }
    public int Year { get; set; }
    public required string MusicFilePath { get; set; }
    public int ArtistId { get; set; }
    public int? AlbumId { get; set; }
}

public class MusicUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Year { get; set; }
    public string? MusicFilePath { get; set; }
    public required int ArtistId { get; set; }
    public int? AlbumId { get; set; }
}
