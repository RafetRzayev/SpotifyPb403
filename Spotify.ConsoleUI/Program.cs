using Microsoft.EntityFrameworkCore;
using Spotify.Application.DTOs.ArtistDtos;
using Spotify.Application.DTOs.MusicDtos;
using Spotify.Application.Interfaces;
using Spotify.Application.Services;
using Spotify.Domain.Entities;

namespace Spotify.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var artistService = new ArtistManager();
            //var artist = artistService.Get(x => x.Id == 1, include: x => x.Include(a => a.ArtistMusics).ThenInclude(x => x.Music));
       
        
            var musicService = new MusicManager();
            var music = musicService.Get(x => x.Id == 7, include: x => x.Include(a => a.ArtistMusics));
            
            var musicUpdateDto = new MusicUpdateDto
            {
                Id = music.Id,
                Name = "Updated Music",
                Year = 2023,
                MusicFilePath = "UpdatedPath",
                RemovedArtistId = new List<int> { 3 },
                //AddedArtistId = new List<int> { 4 },
            };
            musicService.Update(musicUpdateDto);

        }
    }
}
