using Spotify.Application.DTOs.MusicDtos;

namespace Spotify.Application.DTOs.ArtistDtos;

public class ArtistDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<MusicDto> Musics { get; set; } = new();
}

public class ArtistCreateDto
{
    public required string Name { get; set; }
}

public class ArtistUpdateDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
