using AutoMapper;
using DiscoverEgypt.Core.Entities;
using DiscoverEgypt.Core.Features.Payment.DTOs;

namespace DiscoverEgypt.Core.Mapping
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentDto>()
                .ForMember(dest => dest.PaymentMethod,
                    opt => opt.MapFrom(src => src.PaymentMethod.ToString()))
                .ForMember(dest => dest.Status,
                    opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}