using AutoMapper;
using Microsoft.EntityFrameworkCore.Design;
using Spotify.Application.DTOs.AlbumDtos;
using Spotify.Application.DTOs.ArtistDtos;
using Spotify.Application.DTOs.ArtistMusicDtos;
using Spotify.Application.DTOs.MusicDtos;
using Spotify.Domain.Entities;

namespace Spotify.Application.AutoMapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Music, MusicDto>()
            .ForMember(x => x.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title)).ReverseMap();


        CreateMap<MusicCreateDto, Music>()
            .ForMember(x => x.ArtistMusics,
            opt => 
            opt.MapFrom(src => src.ArtistIds.Select(x => new ArtistMusic { ArtistId = x })))
            .ReverseMap();

        CreateMap<Music, MusicUpdateDto>().ReverseMap();
       // CreateMap<Music, Destination>().ForMember(dest => dest.Property, opt => opt.MapFrom(src => src.Property));

        CreateMap<Artist, ArtistDto>().ReverseMap();
        CreateMap<Artist, ArtistCreateDto>().ReverseMap();
        CreateMap<Artist, ArtistUpdateDto>().ReverseMap();

        CreateMap<Album, AlbumDto>().ReverseMap();
        CreateMap<Album, AlbumCreateDto>().ReverseMap();
        CreateMap<Album, AlbumUpdateDto>().ReverseMap();

        CreateMap<ArtistMusic, ArtistMusicDto>()
            .ForMember(x=>x.MusicName, opt=>opt.MapFrom(src=>src.Music.Name))
            .ForMember(x=>x.ArtistName, opt=>opt.MapFrom(src=>src.Artist.Name)).ReverseMap();

    }
}
