using Spotify.Application.DTOs.MusicDtos;
using Spotify.Application.Interfaces;
using Spotify.Domain.Entities;

namespace Spotify.Application.Services;

public class MusicManager : CrudManager<Music, MusicDto, MusicCreateDto, MusicUpdateDto>, IMusicService
{
    public void PlayMusic(string path)
    {
        throw new NotImplementedException();
    }
}