using AutoMapper;
using Microsoft.EntityFrameworkCore.Design;
using Spotify.Application.DTOs.AlbumDtos;
using Spotify.Application.DTOs.ArtistDtos;
using Spotify.Application.DTOs.MusicDtos;
using Spotify.Domain.Entities;

namespace Spotify.Application.AutoMapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Music, MusicDto>()
            .ForMember(x => x.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title)).ReverseMap();
        CreateMap<Music, MusicCreateDto>().ReverseMap();
        CreateMap<Music, MusicUpdateDto>().ReverseMap();
       // CreateMap<Music, Destination>().ForMember(dest => dest.Property, opt => opt.MapFrom(src => src.Property));

        CreateMap<Artist, ArtistDto>().ReverseMap();
        CreateMap<Artist, ArtistCreateDto>().ReverseMap();
        CreateMap<Artist, ArtistUpdateDto>().ReverseMap();

        CreateMap<Album, AlbumDto>().ReverseMap();
        CreateMap<Album, AlbumCreateDto>().ReverseMap();
        CreateMap<Album, AlbumUpdateDto>().ReverseMap();

    }
}
