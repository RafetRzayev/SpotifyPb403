using Microsoft.EntityFrameworkCore;
using Spotify.Application.DTOs.MusicDtos;
using Spotify.Application.Interfaces;
using Spotify.Domain.Entities;
using Spotify.Infrastructure.EfCore.Repositories;

namespace Spotify.Application.Services;

public class MusicManager : CrudManager<Music, MusicDto, MusicCreateDto, MusicUpdateDto>, IMusicService
{
    public void PlayMusic(string path)
    {
        throw new NotImplementedException();
    }

    //public override MusicDto Add(MusicCreateDto createDto)
    //{
    //    Music music = new Music
    //    {
    //        Name = createDto.Name,
    //        Year = createDto.Year,
    //        MusicFilePath = createDto.MusicFilePath,
    //        AlbumId = createDto.AlbumId,
    //    };

    //    foreach (var artistId in createDto.ArtistIds)
    //    {
    //        music.ArtistMusics.Add(new ArtistMusic
    //        {
    //            ArtistId = artistId,
    //        });
    //    }

    //    return Mapper.Map<MusicDto>(Repository.Add(music));
    //}

    public override MusicDto Update(MusicUpdateDto updateDto)
    {
        var music = Repository.Get(x => x.Id == updateDto.Id, include: x => x.Include(y => y.ArtistMusics));
        if (music == null)
            throw new InvalidOperationException("Music not found");

        music.Name = updateDto.Name;
        music.Year = updateDto.Year;
        music.MusicFilePath = updateDto.MusicFilePath;
        music.AlbumId = updateDto.AlbumId;
        music.ArtistMusics.RemoveAll(am => updateDto.RemovedArtistId.Contains(am.ArtistId));
        foreach (var artistId in updateDto.AddedArtistId)
        {
            if (!music.ArtistMusics.Any(am => am.ArtistId == artistId))
            {
                music.ArtistMusics.Add(new ArtistMusic
                {
                    ArtistId = artistId,
                });
            }
        }

        if (updateDto.RemovedArtistId.Count > 0)
        {
            var artistMusicRepository = new EfCoreRepository<ArtistMusic>();

            foreach (var item in updateDto.RemovedArtistId)
            {
                var exitstArtistMusic = artistMusicRepository.Get(x=>x.ArtistId==item && x.MusicId == updateDto.Id);

                if (exitstArtistMusic != null)
                {
                    artistMusicRepository.Delete(exitstArtistMusic);
                }
            }
        }


        return Mapper.Map<MusicDto>(Repository.Update(music));
    }
}