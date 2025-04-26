using Spotify.Application.DTOs.ArtistDtos;
using Spotify.Application.Interfaces;
using Spotify.Domain.Entities;

namespace Spotify.Application.Services;

public class ArtistManager : CrudManager<Artist, ArtistDto, ArtistCreateDto, ArtistUpdateDto>, IArtistService
{

}

