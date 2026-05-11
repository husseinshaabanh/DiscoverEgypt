using AutoMapper;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.Review.DTOs;

namespace DiscoverEgypt.Core.Mapping
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src =>
                        src.Tourist != null && src.Tourist.User != null
                            ? $"{src.Tourist.User.FirstName} {src.Tourist.User.LastName}"
                            : "Unknown"));
        }
    }
}