using Spotify.Application.DTOs.MusicDtos;
using Spotify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Interfaces
{
    public interface IMusicService : ICrudService<Music, MusicDto, MusicCreateDto, MusicUpdateDto>
    {
        void PlayMusic(string path);
    }
}
