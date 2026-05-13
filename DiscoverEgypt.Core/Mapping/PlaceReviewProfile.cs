using AutoMapper;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.Review.DTOs;

namespace DiscoverEgypt.Core.Mapping
{
    public class PlaceReviewProfile : Profile
    {
        public PlaceReviewProfile()
        {
            CreateMap<PlaceReview, PlaceReviewDto>()
                .ForMember(dest => dest.TouristName,
                    opt => opt.MapFrom(src =>
                        $"{src.Tourist.User.FirstName} {src.Tourist.User.LastName}"));
        }
    }
}