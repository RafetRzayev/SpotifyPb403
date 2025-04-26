using Spotify.Application.DTOs.ArtistDtos;
using Spotify.Domain.Entities;

namespace Spotify.Application.Interfaces
{
    public interface IArtistService : ICrudService<Artist, ArtistDto, ArtistCreateDto, ArtistUpdateDto>
    {
    }
}
