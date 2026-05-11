using AutoMapper;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.Favorite.DTOs;

namespace DiscoverEgypt.Core.Mapping
{
    public class FavoriteProfile : Profile
    {
        public FavoriteProfile()
        {
            CreateMap<Favorite, FavoriteDto>()
                .ForMember(dest => dest.PlaceName,
                    opt => opt.MapFrom(src => src.Place.Name))
                .ForMember(dest => dest.City,
                    opt => opt.MapFrom(src => src.Place.City))
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Place.Category.Name))
                .ForMember(dest => dest.AddedAt,
                    opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}