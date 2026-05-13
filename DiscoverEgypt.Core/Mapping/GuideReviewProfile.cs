using AutoMapper;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.GuideReviews.DTOs;

namespace DiscoverEgypt.Core.Mapping
{
    public class GuideReviewProfile : Profile
    {
        public GuideReviewProfile()
        {
            CreateMap<GuideReview, GuideReviewDto>()
                .ForMember(dest => dest.TouristName,
                    opt => opt.MapFrom(src =>
                        $"{src.Tourist.User.FirstName} {src.Tourist.User.LastName}"));
        }
    }
}
