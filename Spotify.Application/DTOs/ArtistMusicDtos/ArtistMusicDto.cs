using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.DTOs.ArtistMusicDtos
{
    public class ArtistMusicDto
    {
        public int Id { get; set; }
        public string? ArtistName { get; set; }
        public string? MusicName { get; set; }
    }
}
