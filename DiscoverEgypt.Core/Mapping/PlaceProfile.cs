using AutoMapper;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.Places.DTOs;

namespace DiscoverEgypt.Core.Mapping
{
    public class PlaceProfile : Profile
    {
        public PlaceProfile()
        {
            CreateMap<Place, PlaceDto>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Latitude,
                    opt => opt.MapFrom(src => src.Location.Latitude))
                .ForMember(dest => dest.Longitude,
                    opt => opt.MapFrom(src => src.Location.Longitude));

            CreateMap<CreatePlaceDto, Place>()
                .ForMember(dest => dest.Location,
                    opt => opt.MapFrom(src => new Location
                    {
                        Latitude = src.Latitude,
                        Longitude = src.Longitude
                    }));
        }
    }
}