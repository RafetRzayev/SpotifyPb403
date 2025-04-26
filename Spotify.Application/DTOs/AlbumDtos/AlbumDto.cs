using Spotify.Application.DTOs.ArtistDtos;
using Spotify.Application.DTOs.MusicDtos;

namespace Spotify.Application.DTOs.AlbumDtos;

public class AlbumDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Year { get; set; }
    public ArtistDto? Artist { get; set; } = null!;
    public List<MusicDto> Musics { get; set; } = new();
}

public class AlbumCreateDto
{
    public required string Title { get; set; }
    public int Year { get; set; }
    public int ArtistId { get; set; }
}

public class AlbumUpdateDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int Year { get; set; }
    public int ArtistId { get; set; }
}